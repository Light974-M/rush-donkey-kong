using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDK : MonoBehaviour
{

    public Transform DK;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, DK.transform.position.y, transform.position.z);
    }
}
