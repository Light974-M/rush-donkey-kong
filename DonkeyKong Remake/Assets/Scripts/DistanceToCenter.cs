using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToCenter : MonoBehaviour
{
    public Transform center;

    float distance;

    void Start()
    {
        
    }

    void Update()
    {


        distance = Vector3.Distance(center.position, transform.position);

        if (distance > 8)
        {
            transform.localPosition += new Vector3(0, 0, 0.1f);
        }



    }
}
