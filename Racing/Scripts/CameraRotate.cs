using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform target;   
 
    void LateUpdate()
    {
        transform.LookAt(target);
    }
}
