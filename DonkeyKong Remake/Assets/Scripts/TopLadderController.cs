using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLadderController : MonoBehaviour
{
    private bool canUp = false;

    void Start()
    {
        
    }

    void Update()
    {
        canUp = Jump.canUp;

        if(canUp)
        {
            transform.localPosition = new Vector3(-2.492592f, 11.586834f, 2.057519f);
        }
        else
        {
            transform.localPosition = new Vector3(-2.492592f, 9.436834f, 2.057519f);
        }
    }



    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Mario"))
        {
            Jump.isTop = true;
        }
    }
}
