using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenController : MonoBehaviour
{
    public Transform marioReste;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("MarioTombe"))
        {
            transform.position = new Vector3(transform.position.x, 504000.64f, transform.position.z);
            marioReste.transform.position = new Vector3(marioReste.transform.position.x, 505000.06f, marioReste.transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 504.64f, transform.position.z);
            marioReste.transform.position = new Vector3(marioReste.transform.position.x, 505.06f, marioReste.transform.position.z);
        }
    }
}
