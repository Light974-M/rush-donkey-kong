using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonneauController : MonoBehaviour
{

    public Transform TonneauMesh;

    private bool isGoingLeft = true;

    private float hauteurTonneau;

    private int animationLadder = 0;

    private bool isHammerTakenOrigin = false;
    private static bool isHammerTaken = false;

    private bool isOnLadder = false;

    public float tonneauSpeed;

    void Start()
    {
        transform.position = new Vector3(0, 13, 0);
        TonneauMesh.transform.position += new Vector3(0, 13, -8f);
        transform.eulerAngles += new Vector3(0, -65, 0);

        isHammerTakenOrigin = Jump.isHammerTaken;
        isHammerTaken = isHammerTakenOrigin;
    }

    void Update()
    {
        hauteurTonneau = TonneauMesh.transform.position.y;


        if (!isOnLadder)
        {
            if (!Jump.deathAnimationStart)
            {
                if (isGoingLeft)
                {
                    transform.eulerAngles += new Vector3(0, tonneauSpeed, 0);
                }
                else
                {
                    transform.eulerAngles -= new Vector3(0, tonneauSpeed, 0);
                }
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

        if(!Jump.deathAnimationStart)
        {
            if (isOnLadder)
            {
                if (animationLadder == 0)
                {
                    transform.eulerAngles += new Vector3(0, 5, 0);
                    TonneauMesh.transform.eulerAngles += new Vector3(0, 90, 0);
                }
                if (animationLadder < 60)
                {
                    transform.position -= new Vector3(0, 0.01f, 0);
                    animationLadder += 1;
                }
                else
                {
                    TonneauMesh.transform.eulerAngles -= new Vector3(0, 90, 0);
                    animationLadder = 0;
                    isOnLadder = false;
                }
            }
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

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("TonneauLadder"))
        {
            isOnLadder = true;
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Bas"))
        {
            Destroy(gameObject);
        }
    }
}
