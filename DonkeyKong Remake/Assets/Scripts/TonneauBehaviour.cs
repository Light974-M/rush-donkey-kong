using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonneauBehaviour : MonoBehaviour
{
    public float time = 1.0f;

    public Transform Spawn;
    public GameObject TonneauGravity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0.0f)
        {
           
            Vector3 position = new Vector3();
            Instantiate(TonneauGravity, Spawn.position, Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }
}
