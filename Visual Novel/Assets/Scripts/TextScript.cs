using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{

    public GameObject nextText;
    public GameObject thisText;
    // Start is called before the first frame update
    void Start()
    {
        nextText.SetActive(false);
        thisText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextText.SetActive(true);
            thisText.SetActive(false);
        }
    }
}
