using System;
using NWH.VehiclePhysics2.GroundDetection;
using NWH.VehiclePhysics2.Powertrain;
using UnityEngine;
using Object = UnityEngine.Object;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
using NWH.NUI;
#endif

namespace NWH.VehiclePhysics2.Effects
{
    /// <summary>
    ///     Skid smoke and surface dust generated by wheel slipping / rolling over the surface.
    /// </summary>
    [Serializable]
    public partial class SurfaceParticleSystem
    {
        /// <summary>
        ///     Coefficient by which the lateral slip will be multiplied.
        ///     Increase the value to emit more particles when there is lateral slip (wheel skid / drift).
        /// </summary>
        [Tooltip(
            "Coefficient by which the lateral slip will be multiplied.\r\nIncrease the value to emit more particles when there is lateral slip (wheel skid / drift).")]
        public float lateralSlipCoeff = 0.5f;

        /// <summary>
        ///     Coefficient by which the longitudinal slip will be multiplied.
        ///     Increase the value to emit more particles when there is longitudinal slip (wheel spin).
        /// </summary>
        [Tooltip(
            "Coefficient by which the longitudinal slip will be multiplied.\r\nIncrease the value to emit more particles when there is longitudinal slip (wheel spin).")]
        public float longitudinalSlipCoeff = 0.5f;

        /// <summary>
        ///     Coefficient by which the particle start size will be multiplied.
        /// </summary>
        [Tooltip("    Coefficient by which the particle start size will be multiplied.")]
        public float particleSizeCoeff = 1f;

        /// <summary>
        ///     Coefficient by which the emission rate will be multiplied.
        /// </summary>
        [Tooltip("    Coefficient by which the emission rate will be multiplied.")]
        public float emissionRateCoeff = 1f;

        /// <summary>
        ///     Makes the particle either emit or not emit with no in-between.
        /// </summary>
        [Tooltip("    Makes the particle either emit or not emit with no in-between.")]
        public bool binaryEmission;

        public ParticleSystem particlePS;
        public ParticleSystem chunkPS;

        public GameObject particlePrefab;
        public GameObject chunkPrefab;

        private ParticleSystem.MainModule _mainModule;
        private ParticleSystem.EmissionModule _emissionModule;
        private ParticleSystem.ShapeModule _shapeModule;
        private float _rateOverDistance;
        private float _rateOverTime;
        private float _smokeEmissionRateVelocity;
        private VehicleController _vc;
        private WheelComponent _wheelComponent;
        private Color _particleColor;
        private ParticleSystem.MinMaxGradient _minMaxGradient;

        [SerializeField]
        private SurfacePreset surfacePreset;

        private float _smokeEmissionRate;
        private Coroutine _chunkCoroutine = null;
        private Coroutine _particleCoroutine = null;

        public void Initialize(VehicleController vc, WheelComponent wheelComponent)
        {
            _vc = vc;
            _wheelComponent = wheelComponent;

            if (!vc.groundDetection.state.isEnabled || vc.groundDetection.groundDetectionPreset == null)
            {
                return;
            }

            // CreateInstance particles
            if (_vc.groundDetection.groundDetectionPreset.particlePrefab != null)
            {
                particlePrefab = Object.Instantiate(
                    _vc.groundDetection.groundDetectionPreset.particlePrefab,
                    wheelComponent.wheelUAPI.transform,
                    true);
                particlePrefab.transform.localPosition = -Vector3.up * wheelComponent.wheelUAPI.SpringMaxLength;
                particlePrefab.transform.localRotation = Quaternion.identity;
                particlePS = particlePrefab.GetComponent<ParticleSystem>();
                particlePS.name = "SurfaceParticles";

                ParticleSystem.ShapeModule shape = particlePS.shape;
                shape.radius = wheelComponent.wheelUAPI.Width * 1.5f;

                _shapeModule = particlePS.shape;
                _shapeModule.radius = wheelComponent.wheelUAPI.Width;
            }
            else
            {
                Debug.LogWarning("Smoke Prefab is null, wheel slip will not produce particles.");
            }

            // CreateInstance chunks
            if (_vc.groundDetection.groundDetectionPreset.chunkPrefab != null)
            {
                chunkPrefab = Object.Instantiate(
                    _vc.groundDetection.groundDetectionPreset.chunkPrefab,
                    wheelComponent.wheelUAPI.transform,
                    true);
                chunkPrefab.transform.localPosition = -Vector3.up * (wheelComponent.wheelUAPI.SpringMaxLength + wheelComponent.wheelUAPI.Radius);
                chunkPrefab.transform.localRotation = Quaternion.identity;
                chunkPS = chunkPrefab.GetComponent<ParticleSystem>();
                chunkPS.name = "SurfaceChunks";

                _shapeModule = chunkPS.shape;
                _shapeModule.radius = wheelComponent.wheelUAPI.Width;
            }
            else
            {
                Debug.LogWarning("Dust Prefab is null, there will be no surface dust.");
            }
        }


        public void Enable()
        {
            _particleCoroutine = _vc.StartCoroutine(UpdateParticlesCoroutine());
            _chunkCoroutine = _vc.StartCoroutine(UpdateChunksCoroutine());

            if (particlePS != null)
            {
                particlePS.Play();
            }

            if (chunkPS != null)
            {
                chunkPS.Play();
            }
        }


        public void Disable()
        {
            if (_particleCoroutine != null)
            {
                _vc.StopCoroutine(_particleCoroutine);
            }

            if (_chunkCoroutine != null)
            {
                _vc.StopCoroutine(_chunkCoroutine);
            }

            if (particlePS != null)
            {
                particlePS.Stop();
            }

            if (chunkPS != null)
            {
                chunkPS.Stop();
            }
        }


        private IEnumerator UpdateParticlesCoroutine()
        {
            float dt = 0.05f;
            while (true)
            {
                yield return new WaitForSeconds(dt);

                bool isGrounded = _wheelComponent.wheelUAPI.IsGrounded;
                surfacePreset = _wheelComponent.surfacePreset;

                if (surfacePreset == null || !surfacePreset.emitParticles || !isGrounded)
                {
                    StopParticleEmission();
                    continue;
                }

                if (particlePS == null) continue;

                _mainModule = particlePS.main;
                _emissionModule = particlePS.emission;

                _mainModule.startColor = surfacePreset.particleColor;
                _mainModule.startSize = surfacePreset.particleSize * particleSizeCoeff;

                // Set lifetime based on speed
                float startLifetime = surfacePreset.particleLifeDistance / _wheelComponent.wheelUAPI.LongitudinalSpeed;
                startLifetime = Mathf.Clamp(startLifetime, 2f, surfacePreset.maxParticleLifetime);
                _mainModule.startLifetime = startLifetime;

                // SMOKE
                if (surfacePreset.particleType == SurfacePreset.ParticleType.Smoke)
                {
                    if (!_wheelComponent.wheelUAPI.IsSkiddingLaterally && !_wheelComponent.wheelUAPI.IsSkiddingLongitudinally)
                    {
                        StopParticleEmission();
                        continue;
                    }

                    if (_vc.Speed < 0.5f && _vc.AngularVelocityMagnitude < 0.5f)
                    {
                        StopParticleEmission();
                        continue;
                    }

                    // Calculate emission rate
                    if (!binaryEmission)
                    {
                        float latEmission = _wheelComponent.wheelUAPI.IsSkiddingLaterally
                                                ? _wheelComponent.wheelUAPI.NormalizedLateralSlip * lateralSlipCoeff
                                                : 0;
                        float lngEmission = _wheelComponent.wheelUAPI.IsSkiddingLongitudinally
                                                ? _wheelComponent.wheelUAPI.NormalizedLongitudinalSlip * longitudinalSlipCoeff
                                                : 0f;
                        float newSmokeEmissionRate = latEmission + lngEmission;
                        newSmokeEmissionRate = Mathf.Clamp01(newSmokeEmissionRate) * surfacePreset.maxParticleEmissionRateOverDistance;
                        _smokeEmissionRate = Mathf.Lerp(_smokeEmissionRate, newSmokeEmissionRate, dt);
                    }
                    else
                    {
                        float latEmission = _wheelComponent.wheelUAPI.IsSkiddingLaterally ? lateralSlipCoeff : 0;
                        float lngEmission = _wheelComponent.wheelUAPI.IsSkiddingLongitudinally ? longitudinalSlipCoeff : 0;
                        float newSmokeEmissionRate = Mathf.Clamp01(latEmission + lngEmission) *
                                               surfacePreset.maxParticleEmissionRateOverDistance;
                        _smokeEmissionRate = newSmokeEmissionRate;
                    }

                    // Set start color alpha value
                    _particleColor = _mainModule.startColor.color;
                    _minMaxGradient = _mainModule.startColor;
                    _minMaxGradient.color = new Color(_particleColor.r, _particleColor.g, _particleColor.b,
                                                      Mathf.Clamp01(_smokeEmissionRate) * surfacePreset.particleMaxAlpha);
                    _mainModule.startColor = _minMaxGradient;

                    // Set emission rates
                    float speedBias = Mathf.Clamp01(_vc.Speed * 0.33f);
                    _rateOverDistance = speedBias * _smokeEmissionRate;
                    _rateOverTime = (1f - speedBias) * _smokeEmissionRate;
                    _emissionModule.rateOverDistance = _rateOverDistance * emissionRateCoeff;
                    _emissionModule.rateOverTime = _rateOverTime * emissionRateCoeff;
                }
                // DUST
                else
                {
                    // Calculate emission rate
                    float dustEmissionRate = 0f;
                    if (_wheelComponent.wheelUAPI.IsGrounded)
                    {
                        dustEmissionRate = Mathf.Clamp01(_vc.Speed * 0.125f - 0.05f) *
                                           surfacePreset.maxParticleEmissionRateOverDistance;
                    }

                    // Set start color alpha value
                    _particleColor = _mainModule.startColor.color;
                    _minMaxGradient = _mainModule.startColor;
                    _minMaxGradient.color = new Color(_particleColor.r, _particleColor.g, _particleColor.b,
                                                      Mathf.Clamp01(dustEmissionRate * 2f) *
                                                      surfacePreset.particleMaxAlpha);
                    _mainModule.startColor = _minMaxGradient;

                    // Set emission rates
                    _emissionModule.rateOverTime = 0;
                    _emissionModule.rateOverDistance = dustEmissionRate * emissionRateCoeff;
                }
            }
        }


        private IEnumerator UpdateChunksCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);

                bool isGrounded = _wheelComponent.wheelUAPI.IsGrounded;
                surfacePreset = _wheelComponent.surfacePreset;

                if (surfacePreset == null || !surfacePreset.emitChunks || !isGrounded)
                {
                    StopChunkEmission();
                    continue;
                }

                if (chunkPS == null) continue;

                chunkPS.gameObject.transform.localPosition = -Vector3.up * (_wheelComponent.wheelUAPI.SpringLength + _wheelComponent.wheelUAPI.Radius);

                _mainModule = chunkPS.main;
                _emissionModule = chunkPS.emission;

                // Set lifetime based on speed
                float startLifetime = surfacePreset.chunkLifeDistance / _wheelComponent.wheelUAPI.LongitudinalSpeed;
                startLifetime = Mathf.Clamp(startLifetime, 0.2f, surfacePreset.maxChunkLifetime);
                _mainModule.startLifetime = startLifetime;

                float angVel = _wheelComponent.outputAngularVelocity;
                float absAngVel = angVel < 0 ? -angVel : angVel;
                if (absAngVel < 5f)
                {
                    _emissionModule.rateOverTime = 0;
                    _emissionModule.rateOverDistance = 0;
                }
                else
                {
                    // Set speed based on wheel angular velocity
                    float tangentialWheelSpeed = _wheelComponent.outputAngularVelocity * _wheelComponent.wheelUAPI.Radius;
                    _mainModule.startSpeed = tangentialWheelSpeed * 0.2f;
                    _emissionModule.rateOverTime = 0;
                    _emissionModule.rateOverDistance = (_wheelComponent.wheelUAPI.NormalizedLongitudinalSlip * 0.7f +
                                                        _wheelComponent.wheelUAPI.NormalizedLateralSlip * 0.3f)
                                                       * surfacePreset.maxChunkEmissionRateOverDistance;
                }
            }
        }


        private void StopParticleEmission()
        {
            if (particlePS == null)
            {
                return;
            }

            _emissionModule = particlePS.emission;
            _emissionModule.rateOverDistance = 0;
            _emissionModule.rateOverTime = 0;
        }


        private void StopChunkEmission()
        {
            if (chunkPS == null)
            {
                return;
            }

            _emissionModule = chunkPS.emission;
            _emissionModule.rateOverDistance = 0;
            _emissionModule.rateOverTime = 0;
        }
    }
}