using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MidiManager : MonoBehaviour, MidiInputShit.IMainActions
{
    public MidiButton button_1_Low;
    public MidiButton button_2_Low;
    public MidiButton button_3_Low;
    public MidiButton button_4_Low;
    public MidiButton button_5_Low;
    public MidiButton button_6_Low;
    public MidiButton button_7_Low;
    public MidiButton button_8_Low;
    
    public Slider slider77;
    public Slider slider78;
    public Slider slider79;
    public Slider slider80;
    public Slider slider81;
    public Slider slider82;
    public Slider slider83;
    public Slider slider84;

    private MidiInputShit midiInputShit;

    private void Awake()
    {
        midiInputShit = new MidiInputShit();
        midiInputShit.Main.SetCallbacks(this);
        midiInputShit.Main.Enable();
    }

    public void OnSlider(InputAction.CallbackContext context)
    {
        Debug.Log("Slider");
    }

    public void OnTest(InputAction.CallbackContext context)
    {
        Debug.Log("Test");
    }

    public void OnNewaction(InputAction.CallbackContext context)
    {
        Debug.Log("Newaction");
    }

    public void OnSlider_77(InputAction.CallbackContext context)
    {
        slider77.value = context.ReadValue<float>();
    }

    public void OnSlider_78(InputAction.CallbackContext context)
    {
        slider78.value = context.ReadValue<float>();
    }

    public void OnSlider_79(InputAction.CallbackContext context)
    {
        slider79.value = context.ReadValue<float>();
    }

    public void OnSlider_80(InputAction.CallbackContext context)
    {
        slider80.value = context.ReadValue<float>();
    }

    public void OnSlider_81(InputAction.CallbackContext context)
    {
        slider81.value = context.ReadValue<float>();
    }

    public void OnSlider_82(InputAction.CallbackContext context)
    {
        slider82.value = context.ReadValue<float>();
    }

    public void OnSlider_83(InputAction.CallbackContext context)
    {
        slider83.value = context.ReadValue<float>();
    }

    public void OnSlider_84(InputAction.CallbackContext context)
    {
        slider84.value = context.ReadValue<float>();
    }

    public void OnButton_1(InputAction.CallbackContext context)
    {
        button_1_Low.SetEnabled(context.ReadValueAsButton());
    }

    public void OnButton_2(InputAction.CallbackContext context)
    {
        button_2_Low.SetEnabled(context.ReadValueAsButton());
    }

    public void OnButton_3(InputAction.CallbackContext context)
    {
        button_3_Low.SetEnabled(context.ReadValueAsButton());
    }

    public void OnButton_4(InputAction.CallbackContext context)
    {
        button_4_Low.SetEnabled(context.ReadValueAsButton());
    }

    public void OnButton_5(InputAction.CallbackContext context)
    {
        button_5_Low.SetEnabled(context.ReadValueAsButton());
    }

    public void OnButton_6(InputAction.CallbackContext context)
    {
        button_6_Low.SetEnabled(context.ReadValueAsButton());
    }

    public void OnButton_7(InputAction.CallbackContext context)
    {
        button_7_Low.SetEnabled(context.ReadValueAsButton());
    }

    public void OnButton_8(InputAction.CallbackContext context)
    {
        button_8_Low.SetEnabled(context.ReadValueAsButton());
    }

    public void OnRightTurntable(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
        Debug.Log("Right Turntable: " + value);
    }

    public void OnButton_8_Low(InputAction.CallbackContext context)
    {
        button_8_Low.SetEnabled(context.ReadValueAsButton());
    }
}
