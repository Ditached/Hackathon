using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedSign : MonoBehaviour
{
    public int SpeedLimit = 70;
    public TMP_Text speedLimitText;
    
    void Update()
    {
        speedLimitText.text = SpeedLimit.ToString();
    }

    public void ApplySpeed()
    {
        FindObjectOfType<MusicController>().currentSpeedLimit = SpeedLimit;
    }
}
