using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioCapsuleController : MonoBehaviour
{
    public static float playerXAxis = 0;
    public static float playerYAxis = 0;
    public static float playerZAxis = 0;

    void Start()
    {
        
    }

    void Update()
    {
        playerXAxis = transform.localPosition.x;
        playerYAxis = transform.localPosition.y;
        playerZAxis = transform.localPosition.z;

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180, transform.localEulerAngles.z);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
        }
    }
}
