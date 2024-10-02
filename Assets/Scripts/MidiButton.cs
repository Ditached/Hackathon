using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MidiButton : MonoBehaviour
{
    public Color active;
    public Color inactive;
    
    public void SetEnabled(bool enabled)
    {
        if (enabled)
        {
            GetComponent<Image>().color = active;
        }
        else
        {
            GetComponent<Image>().color = inactive;
        }
    }
}
