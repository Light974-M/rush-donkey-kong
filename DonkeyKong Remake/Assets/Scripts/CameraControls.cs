using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Vector3 rotateSpeed = new Vector3(0, 1, 0);
    public Vector3 minusRotateSpeed = new Vector3(0, -1, 0);

    // Start is called before the first frame update
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {



        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(rotateSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(minusRotateSpeed);
        }

    }

}