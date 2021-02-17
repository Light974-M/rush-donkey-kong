using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    public Collider capsuleCollider;
    public GameObject Pivot;
   
    AudioSource getCoin;

    public GameObject GetCoin;

    void Start()
    {
        getCoin = GetCoin.GetComponent<AudioSource>();
        //capsuleCollider.isTrigger = true;
    }

    void Update()
    {

    }


    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Mario"))
        {
            getCoin.Play();
            GameObject.Destroy(Pivot);
        }
    }

   /* void OnTriggerEnter(Collider other)
    {
        getCoin.Play();
        GameObject.Destroy(Pivot);
    }*/
}
