using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepTonneauController : MonoBehaviour
{


   /* private int randomLadder;
    public static bool isOnLadderSms = false;
    private bool isOnLadderInit = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnLadderInit)
        {
            isOnLadderSms = isOnLadderInit;
            transform.position = new Vector3(transform.position.x, 100000, transform.position.z);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 15.79f, transform.localPosition.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Tonneau"))
        {
            randomLadder = Random.Range(0, 1);
            if (randomLadder == 0)
            {
                isOnLadderInit = true;
            }
        }
    }*/
}
