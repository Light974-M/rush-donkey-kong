using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DKlauncher : MonoBehaviour
{
    public float time = 3;

    public Transform SpawnTonneau;
    public GameObject Tonneau;

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
            Instantiate(Tonneau, SpawnTonneau.position, Quaternion.identity);
            time = 3;
        }
    }
}
