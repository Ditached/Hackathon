using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using NWH.VehiclePhysics2;
using Sirenix.OdinInspector;

public enum AmpelState
{
    Green = 0,
    Red = 1,
    Yellow = 2
}

public class Ampel : MonoBehaviour
{
    public float targetVelocityAfter = 50f;
    [ReadOnly]
    public bool tooLate;
    public VehicleController vc;

    [ReadOnly] public float carSpeed;
    [ReadOnly] public float distanceToCar;
    [ReadOnly] public float timeStayedInTargetVelocity = 0f;
    public float calcWindow = 30f;
    public float targetVelocity = 50f;
    public float targetVelcoityWindow = 5f;
    public float minTimeToStayInTargetVelocity = 5f;
    public float distanceToSwitchToGreen;
    
    // G R Y 
    // Green = 0
    // Red = 1
    // Yellow = 2
    [Range(0,2)]
    public int state = 0;
    
    public AmpelState ampelColor => (AmpelState) state;
    public bool TrackingActive;

    public List<Material> activeMaterials;
    public List<Material> inactiveMaterials;

    private MeshRenderer meshRenderer;

    void Start()
    {
        vc = FindObjectOfType<VehicleController>();
        meshRenderer = GetComponent<MeshRenderer>();
        SetToRed();
    }

    private bool switchFlag;

    public IEnumerator SwitchToGreen()
    {
        SetToYellow();
        yield return new WaitForSeconds(1f);
        SetToGreen();
    }

    public IEnumerator SwitchToGreenTooLate()
    {
        SetToRed();
        yield return new WaitForSeconds(8f);
        SetToYellow();
        yield return new WaitForSeconds(1f);
        SetToGreen();
    }
    
    private bool enterFlag = false;

    void Update()
    {
        //ApplyMaterial();
        
        var distance = Vector3.Distance(vc.transform.position, transform.position);
        distanceToCar = distance;
        
        var speed = vc.Speed * 3.6f;
        carSpeed = speed;

        if (TrackingActive)
        {
            if (!enterFlag)
            {
                enterFlag = true;
                FindObjectOfType<MusicController>().currentSpeedLimit = targetVelocity;
            }
            
            if (speed >= targetVelocity - targetVelcoityWindow && speed <= targetVelocity + targetVelcoityWindow)
            {
                timeStayedInTargetVelocity += Time.deltaTime;
            }
            else
            {
                if (timeStayedInTargetVelocity > 0f)
                {
                    timeStayedInTargetVelocity -= Time.deltaTime * 3f;
                }
            }
        }
        else
        {
            timeStayedInTargetVelocity = 0f;
            switchFlag = false;
            enterFlag = false;
            tooLate = false;
        }
    }
    
    public void Set(AmpelState state)
    {
        this.state = (int) state;
        ApplyMaterial();
    }
    
    public void SetToGreen()
    {
        state = 0;
        ApplyMaterial();

        if (TrackingActive)
        {
            FindObjectOfType<MusicController>().currentSpeedLimit = targetVelocityAfter;
        }
    }
    
    public void SetToRed()
    {
        state = 1;
        ApplyMaterial();
    }
    
    public void SetToYellow()
    {
        state = 2;
        ApplyMaterial();
    }

    private void ApplyMaterial()
    {
        Material[] materials = new Material[meshRenderer.sharedMaterials.Length];
        
        for (int i = 0; i < materials.Length; i++)
        {
            if (i == 0) // Assuming the first material should not change
            {
                materials[i] = meshRenderer.sharedMaterials[i];
            }
            else
            {
                int index = i - 1;
                materials[i] = (state == index) ? activeMaterials[index] : inactiveMaterials[index];
            }
        }
        
        meshRenderer.sharedMaterials = materials;
    }

    public void MakeDecision()
    {
        if (switchFlag == false)
        {
            switchFlag = true;
            StopAllCoroutines();

            if (timeStayedInTargetVelocity >= minTimeToStayInTargetVelocity)
            {
                StartCoroutine(SwitchToGreen());
            }
            else
            {
                FindObjectOfType<MusicController>().currentSpeedLimit = 0;
                tooLate = true;
                StartCoroutine(SwitchToGreenTooLate());
            }
        }
    }

    public void AmpelOver()
    {
        TrackingActive = false;
        FindObjectOfType<MusicController>().currentSpeedLimit = targetVelocityAfter;
        SetToRed();
    }
}