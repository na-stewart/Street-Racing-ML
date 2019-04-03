using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenSwitches;
    private Camera[] cameras;
    private int activatedCam;

    // Start is called before the first frame update
    void Start()
    {
        cameras = GetComponentsInChildren<Camera>();   
        StartCoroutine(ActivateCamera());

    }
    
    private IEnumerator ActivateCamera()
    {
       for (int i = 0; i < cameras.Length; i++)
       {
            if (i == activatedCam)
                cameras[i].enabled = true;
            else
                cameras[i].enabled = false;
       }
        yield return new WaitForSeconds(timeBetweenSwitches);      
        activatedCam++;
        if (activatedCam == cameras.Length)
            activatedCam = 0;
        StartCoroutine(ActivateCamera());
           
    }
}
