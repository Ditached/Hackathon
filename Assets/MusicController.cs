using System;
using System.Collections;
using System.Collections.Generic;
using NWH.Common.Vehicles;
using NWH.VehiclePhysics2;
using NWH.VehiclePhysics2.Sound.SoundComponents;
using Sirenix.OdinInspector;
using UnityEngine;
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


    public float targetSpeed = 50f;
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
    
     [Title("Blinker")]
    public AudioSource blinkerLeft;
    public AudioSource blinkerRight;
    public float fadeSpeed = 10f;
    public float maxBlinkerVolume = 0.6f;

    [ReadOnly] public bool blinkerLeftOn;
    [ReadOnly] public bool blinerRightOn;
    
    public InputAction blinkerLeftAction;
    public InputAction blinkerRightAction;

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
        
        var percent = currentSpeed / targetSpeed;
        
        foreach (var musicLayer in musicLayers)
        {
            musicLayer.Update(percent);
        }

   
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
