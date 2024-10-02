using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicatorHider : MonoBehaviour
{
    public GameObject indicator;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            indicator.SetActive(!indicator.activeSelf);
        }
    }
}
