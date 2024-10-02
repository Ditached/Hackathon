using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpelOver : MonoBehaviour
{
    public Ampel ampel;
    
    private void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            ampel.AmpelOver();
            // ampel.TrackingActive = false;
            
        }
    }

}
