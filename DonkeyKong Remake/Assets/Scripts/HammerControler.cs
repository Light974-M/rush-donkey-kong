using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerControler : MonoBehaviour
{
    private bool isHammerTaken = false;

    public Transform hammer;
    public Transform mario;
    private float marioXAxis = 0;
    private float marioYAxis = 0;
    private float marioZAxis = 0;
    private int timer = 1;
    private int timerStack = 0;
    public ParticleSystem dust;

    void Start()
    {
        dust.Stop();
    }


    void Update()
    {
        marioXAxis = Jump.playerXAxis;
        marioYAxis = Jump.playerYAxis;
        marioZAxis = Jump.playerZAxis;

        isHammerTaken = Jump.isHammerTaken;

        if(isHammerTaken)
        {
            Destroy(GetComponent<Collider>());
            hammer.transform.SetParent(mario.transform.parent);
            transform.localPosition = new Vector3(marioXAxis -0.2f, marioYAxis + 2.5f, marioZAxis);

            if(timerStack < 20)
            {
                if(timer > 0 && timer <15)
                {
                    dust.Stop();
                    transform.eulerAngles = new Vector3(-45, transform.eulerAngles.y, transform.eulerAngles.z);
                    timer += 1;
                }
                if(timer == 15)
                {
                    timer = 0;
                }
                if(timer <=0 && timer > -15)
                {
                    if(timer == 0)
                    {
                        dust.Play();
                    }
                    transform.eulerAngles = new Vector3(45, transform.eulerAngles.y, transform.eulerAngles.z);
                    timer -= 1;
                }
                if(timer == -15)
                {
                    timer = 1;
                }
            }
        }
    }
}
