using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLadderController : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Mario"))
        {
            Jump.isTop = false;
        }
    }
}
