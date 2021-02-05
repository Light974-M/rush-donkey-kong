using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DKlauncher : MonoBehaviour
{
    private float time = 2;

    public Transform SpawnTonneau;
    public GameObject Tonneau;

    private int dkRandSpeed;

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
            dkRandSpeed = Random.Range(0, 2);
            time = 2 +(4*dkRandSpeed);
        }
    }
}
