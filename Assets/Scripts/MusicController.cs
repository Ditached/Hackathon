using System;
using System.Collections;
using System.Collections.Generic;
using NWH.Common.Vehicles;
using NWH.VehiclePhysics2;
using NWH.VehiclePhysics2.Sound.SoundComponents;
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
    public List<MusicLayer> musicLayers;

    [Title("General")]
    public Rigidbody rb;
    public VehicleController vehicleController;


    public float targetSpeedForAllMusicLayers = 50f;
    [ReadOnly] public float currentSpeed = 0f;
    
    [Title("Acceleration, Braking")]
    public float maxAccl = 7f;
    public float maxAcclDeclVolume = 0.6f;
    
    public bool enableAcclSound = false;
    public AudioSource accleleration;
    public AudioSource deceleration;
    
    [ReadOnly] public Vector3 localAcceleration;
    [ReadOnly] public Vector3 localAccelerationLerped;
    public float acclLerpSpeed = 2f;


    [Title("Too fast")] 
    public float currentSpeedLimit = 50f;
    [ReadOnly] public float speedOverLimit = 0f;
    public float minSpeedOverGreyArea = 5f;
    public AudioSource goingTooFast;
    public float maxOverSpeed = 20f;
    public TMP_Text speedLimitText;
    public float maxTooFastVolume = 0.7f;
    public AudioMixer audioMixer;
    public float maxPitch = 20f;
    
     [Title("Blinker")]
    public AudioSource blinkerLeft;
    public AudioSource blinkerRight;
    public float fadeSpeed = 10f;
    public float maxBlinkerVolume = 0.6f;

    [ReadOnly] public bool blinkerLeftOn;
    [ReadOnly] public bool blinerRightOn;
    
    public InputAction blinkerLeftAction;
    public InputAction blinkerRightAction;

    [Title("Steering")] 
    [ReadOnly] public float currentAngle;
    public float maxSteeringAngle = 14f;
    public float maxSteeringVolume = 0.6f;
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
        currentSpeed = vehicleController.Speed * 3.6f;
        
        var percent = currentSpeed / targetSpeedForAllMusicLayers;
        
        foreach (var musicLayer in musicLayers)
        {
            musicLayer.Update(percent);
        }

        
        currentAngle = vehicleController.steering.angle;
        steering.volume = Mathf.InverseLerp(0, maxSteeringAngle, Mathf.Abs(currentAngle)) * maxSteeringVolume;
        
        
        speedOverLimit = Mathf.Max(0, currentSpeed - minSpeedOverGreyArea - currentSpeedLimit);
        goingTooFast.volume = Mathf.InverseLerp(0, maxOverSpeed, speedOverLimit) * maxTooFastVolume;
        speedLimitText.text = currentSpeedLimit.ToString("F0");
        
        //Setting pith
        audioMixer.SetFloat("Pitch", 1f + Mathf.InverseLerp(0, maxOverSpeed, speedOverLimit) * maxPitch);
   
        localAcceleration = vehicleController.LocalAcceleration;
        
        
        localAccelerationLerped = Vector3.Lerp(localAccelerationLerped, localAcceleration, Time.deltaTime * acclLerpSpeed);
        
        if(enableAcclSound) accleleration.volume = Mathf.InverseLerp(0, maxAccl, localAccelerationLerped.z) * maxAcclDeclVolume;
        deceleration.volume = Mathf.InverseLerp(0, maxAccl, -localAccelerationLerped.z) * maxAcclDeclVolume;

        var blinkerLeftVolume = blinkerLeftOn ? maxBlinkerVolume : 0f;
        var blinkerRightVolume = blinerRightOn? maxBlinkerVolume : 0f;
        
        blinkerLeft.volume = Mathf.Lerp(blinkerLeft.volume, blinkerLeftVolume, Time.deltaTime * fadeSpeed);
        blinkerRight.volume = Mathf.Lerp(blinkerRight.volume, blinkerRightVolume, Time.deltaTime * fadeSpeed);
    }
}
