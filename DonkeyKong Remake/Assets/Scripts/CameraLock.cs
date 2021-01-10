using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public Transform DK;

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(DK);
    }
}
