using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleResetter : MonoBehaviour
{
    public GameObject car;
    
    private Vector3 startPosition;
    private Quaternion startRotation;
    
    void Start()
    {
        startPosition = car.transform.position;
        startRotation = car.transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        
    }

    private void Restart()
    {
        car.GetComponent<Rigidbody>().position = startPosition;
        car.GetComponent<Rigidbody>().velocity = Vector3.zero;
        car.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        car.GetComponent<Rigidbody>().rotation = startRotation;
        
        car.transform.position = startPosition;
        car.transform.rotation = startRotation;
        
        foreach (var ampel in FindObjectsOfType<Ampel>())
        {
            ampel.ResetAmpel();
        }
        
    }
}
