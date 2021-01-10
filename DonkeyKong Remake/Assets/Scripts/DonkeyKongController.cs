using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyKongController : MonoBehaviour
{
    public Transform mario;

    void Start()
    {
        
    }


    void Update()
    {
        transform.LookAt(mario);
    }
}
