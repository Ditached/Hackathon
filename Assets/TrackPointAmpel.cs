using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPointAmpel : MonoBehaviour
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
            ampel.TrackingActive = true;
        }
    }

}
