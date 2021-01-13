using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonneauBehaviour : MonoBehaviour
{
    public float time = 1.0f;

    public Transform Spawn;
    public GameObject TonneauGravity;
    private bool isHammerTakenOrigin = false;
    private static bool isHammerTaken = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isHammerTakenOrigin = Jump.isHammerTaken;
        isHammerTaken = isHammerTakenOrigin;

        time -= Time.deltaTime;

        if (time <= 0.0f)
        {
           
            Vector3 position = new Vector3();
            Instantiate(TonneauGravity, Spawn.position, Quaternion.identity);
            GameObject.Destroy(gameObject);
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
    }


}
