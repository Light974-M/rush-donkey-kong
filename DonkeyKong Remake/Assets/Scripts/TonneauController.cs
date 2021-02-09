using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonneauController : MonoBehaviour
{

    public Transform TonneauMesh;

    private bool isGoingLeft = true;

    private float hauteurTonneau;


    private bool isHammerTakenOrigin = false;
    private static bool isHammerTaken = false;

    void Start()
    {
        transform.position = new Vector3(0, 10, 0);
        TonneauMesh.transform.position += new Vector3(0, 10, -8f);

        isHammerTakenOrigin = Jump.isHammerTaken;
        isHammerTaken = isHammerTakenOrigin;
    }

    void Update()
    {
        hauteurTonneau = TonneauMesh.transform.position.y;

        if(!Jump.deathAnimationStart)
        {
            if (isGoingLeft)
            {
                transform.eulerAngles += new Vector3(0, 1f, 0);
            }
            else
            {
                transform.eulerAngles -= new Vector3(0, 1f, 0);
            }
        }

        if(transform.position.y > hauteurTonneau)
        {
            isGoingLeft = false;
        }
        else if(transform.position.y < hauteurTonneau)
        {
            isGoingLeft = false;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Mario") || collision.collider.gameObject.layer == LayerMask.NameToLayer("Marteau"))
        {
            if (isHammerTaken)
            {
                GameObject.Destroy(gameObject);
            }
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Mario"))
        {
            if (!isHammerTaken)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}
