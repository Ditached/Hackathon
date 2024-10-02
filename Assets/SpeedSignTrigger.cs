using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSignTrigger : MonoBehaviour
{
    public SpeedSign speedSign;
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Vehicle"))
        {
            speedSign.ApplySpeed();
        }
    }
}
