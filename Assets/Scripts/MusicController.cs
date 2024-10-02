using System;
using System.Collections;
using System.Collections.Generic;
using NWH.Common.Vehicles;
using NWH.VehiclePhysics2;
using NWH.VehiclePhysics2.Sound.SoundComponents;
using Shapes;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;


[Serializable]
public class MusicLayer
{
    public AudioSource audioSource;

    [MinMaxSlider(-0.1f, 1f)] public Vector2 minMaxSpeedPercent;

    public void Update(float percent)
    {
        var value = Mathf.InverseLerp(minMaxSpeedPercent.x, minMaxSpeedPercent.y, percent);
        audioSource.volume = value;
    }
}

public class MusicController : MonoBehaviour
{
    public Rectangle leftRect;
    public Rectangle rightRect;
    public Disc goldenZoneDisc;
    public float goldenZoneLerpSpeed = 2f;
    public Disc speedDisc;
    public List<MusicLayer> musicLayers;

    [Title("General")] public Rigidbody rb;
    public VehicleController vehicleController;


    public float targetSpeedForAllMusicLayers = 50f;
    [ReadOnly] public float currentSpeed = 0f;

    [Title("Acceleration, Braking")] public float maxAccl = 7f;
    public float maxAcclDeclVolume = 0.6f;

    public bool enableAcclSound = false;
    public AudioSource accleleration;
    public AudioSource deceleration;

    [ReadOnly] public Vector3 localAcceleration;
    [ReadOnly] public Vector3 localAccelerationLerped;
    public float acclLerpSpeed = 2f;


    [Title("Too fast / too slow")] 
    public bool enablePitch = false;
    public float currentSpeedLimit = 50f;
    [ReadOnly] public float speedOverLimit = 0f;
    [ReadOnly] public float speedUnderLimit = 0f;
    public float minSpeedOverGreyArea = 5f;
    public AudioSource goingTooFast;
    public AudioSource goingTooSlow;
    public float maxOverSpeed = 20f;
    public TMP_Text speedLimitText;
    public float maxTooFastVolume = 0.7f;
    public float maxTooSlowVolume = 0.7f;

    public bool enableGoldenSpeed = false;
    public AudioSource goldenSpeed;
    public AudioSource goldenSpeed2;
    public float maxGoldenSpeedVolume = 0.7f;
    public float goldenSpeedRange = 5f;
    public float goldenSpeedSoundLerpSpeed = 2f;
    
    
    public AudioMixer audioMixer;
    public float maxPitch = 20f;
    public float minSpeedForTooSlowToKickIn = 20f;

    [Title("Blinker")] public AudioSource blinkerLeft;
    public AudioSource blinkerRight;
    public float fadeSpeed = 10f;
    public float maxBlinkerVolume = 0.6f;

    [ReadOnly] public bool blinkerLeftOn;
    [ReadOnly] public bool blinerRightOn;

    public InputAction blinkerLeftAction;
    public InputAction blinkerRightAction;

    [Title("Steering")] public bool enableSteeringSound = false;
    [ReadOnly] public float currentAngle;
    public float maxSteeringAngle = 14f;
    public float maxSteeringVolume = 0.6f;
    public float steeringLerpSpeed = 2f;
    public AudioSource steering;

    

    private void Awake()
    {
        blinkerLeftAction.performed += ctx => blinkerLeftOn = !blinkerLeftOn;
        blinkerLeftAction.Enable();

        blinkerRightAction.performed += ctx => blinerRightOn = !blinerRightOn;
        blinkerRightAction.Enable();
    }

    private void Update()
    {
        var amples = FindObjectsOfType<Ampel>();
        
        var nearestAmpel = amples[0];
        
        foreach (var ampel in amples)
        {
            if (Vector3.Distance(vehicleController.transform.position, ampel.transform.position) <
                Vector3.Distance(vehicleController.transform.position, nearestAmpel.transform.position))
            {
                nearestAmpel = ampel;
            }
        }
        
        currentSpeed = vehicleController.Speed * 3.6f;
        speedDisc.AngRadiansEnd = currentSpeed * Mathf.Deg2Rad;
        
        
        var angRadStart = Mathf.Lerp(goldenZoneDisc.AngRadiansStart, (currentSpeedLimit - goldenSpeedRange) * Mathf.Deg2Rad, Time.deltaTime * goldenZoneLerpSpeed);
        goldenZoneDisc.AngRadiansStart = angRadStart;
        
        var angRadEnd = Mathf.Lerp(goldenZoneDisc.AngRadiansEnd, (currentSpeedLimit + goldenSpeedRange) * Mathf.Deg2Rad, Time.deltaTime * goldenZoneLerpSpeed);
        goldenZoneDisc.AngRadiansEnd = angRadEnd;

        var percent = currentSpeed / targetSpeedForAllMusicLayers;

        foreach (var musicLayer in musicLayers)
        {
            musicLayer.Update(percent);
        }


        if (enableSteeringSound)
        {
            currentAngle = vehicleController.steering.angle;
            var steeringTargetVolume =
                Mathf.InverseLerp(0, maxSteeringAngle, Mathf.Abs(currentAngle)) * maxSteeringVolume;
            steering.volume = Mathf.Lerp(steering.volume, steeringTargetVolume, Time.deltaTime * steeringLerpSpeed);
        }

        leftRect.Width = Mathf.InverseLerp(0, -maxSteeringAngle, currentAngle) * 5f;
        rightRect.Width = Mathf.InverseLerp(0, maxSteeringAngle, currentAngle) * 5f;

        if (enableGoldenSpeed)
        {
            var diff = Mathf.Abs(currentSpeed - currentSpeedLimit);
            
            if(diff < goldenSpeedRange)
            {
                goldenSpeed.volume = Mathf.Lerp(goldenSpeed.volume, maxGoldenSpeedVolume, Time.deltaTime * goldenSpeedSoundLerpSpeed);
                goldenSpeed2.volume = Mathf.Lerp(goldenSpeed2.volume, maxGoldenSpeedVolume, Time.deltaTime * goldenSpeedSoundLerpSpeed);
            }
            else
            {
                goldenSpeed.volume = Mathf.Lerp(goldenSpeed.volume, 0f, Time.deltaTime * goldenSpeedSoundLerpSpeed);
                goldenSpeed2.volume = Mathf.Lerp(goldenSpeed2.volume, 0f, Time.deltaTime * goldenSpeedSoundLerpSpeed);
            }
            
        }

        
        speedOverLimit = Mathf.Max(0, currentSpeed - minSpeedOverGreyArea - currentSpeedLimit);
        goingTooFast.volume = Mathf.InverseLerp(0, maxOverSpeed, speedOverLimit) * maxTooFastVolume;
        speedLimitText.text = currentSpeedLimit.ToString("F0");

        speedUnderLimit = Mathf.Max(0, currentSpeedLimit - currentSpeed - minSpeedOverGreyArea);

        if (currentSpeed < minSpeedForTooSlowToKickIn)
        {
            goingTooSlow.volume = 0f;
        }
        else
        {
            goingTooSlow.volume = Mathf.InverseLerp(0, maxOverSpeed, speedUnderLimit)  * maxTooSlowVolume;
        }


        //Setting pith
        if (enablePitch)
        {
            audioMixer.SetFloat("Pitch", 1f + Mathf.InverseLerp(0, maxOverSpeed, speedOverLimit) * maxPitch);
        }

        localAcceleration = vehicleController.LocalAcceleration;


        localAccelerationLerped =
            Vector3.Lerp(localAccelerationLerped, localAcceleration, Time.deltaTime * acclLerpSpeed);

        if (enableAcclSound)
            accleleration.volume = Mathf.InverseLerp(0, maxAccl, localAccelerationLerped.z) * maxAcclDeclVolume;
        deceleration.volume = Mathf.InverseLerp(0, maxAccl, -localAccelerationLerped.z) * maxAcclDeclVolume;

        var blinkerLeftVolume = blinkerLeftOn ? maxBlinkerVolume : 0f;
        var blinkerRightVolume = blinerRightOn ? maxBlinkerVolume : 0f;

        blinkerLeft.volume = Mathf.Lerp(blinkerLeft.volume, blinkerLeftVolume, Time.deltaTime * fadeSpeed);
        blinkerRight.volume = Mathf.Lerp(blinkerRight.volume, blinkerRightVolume, Time.deltaTime * fadeSpeed);

        if (!vehicleController.brakes.IsBraking)
        {
            vehicleController.brakes.brakeOffThrottleIntensity = 0.3f;
        }
    }
}