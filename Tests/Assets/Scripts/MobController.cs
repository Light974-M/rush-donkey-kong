using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{

    public GameObject Loot;
    public GameObject Explosion;
    public Transform LootPosition;
    public Transform LootP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Instantiate(Loot, LootP.position, Quaternion.identity);
            Instantiate(Explosion, LootPosition.position, Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }
   
}
