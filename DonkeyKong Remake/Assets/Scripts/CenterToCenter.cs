using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterToCenter : MonoBehaviour
{
    public Transform mario;

    void Start()
    {
        
    }


    void Update()
    {
        transform.position = new Vector3(0, mario.transform.position.y, 0);
    }
}
