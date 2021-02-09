using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    public GameObject thisText;
    public GameObject yes;
    public GameObject no;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Yes()
    {
        yes.SetActive(true);
        thisText.SetActive(false);
    }
    public void No()
    {
        no.SetActive(true);
        thisText.SetActive(false);
    }
}
