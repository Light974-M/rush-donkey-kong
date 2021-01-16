using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoLadderController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Jump.canPressUp)
        {
            transform.localPosition = new Vector3(4.26f, 325.2f, -0.72f);
        }
        else
        {
            transform.localPosition = new Vector3(40000, 32500, 10000);
        }
    }
}
