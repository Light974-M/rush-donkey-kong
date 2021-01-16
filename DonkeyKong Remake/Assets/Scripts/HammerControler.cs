using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerControler : MonoBehaviour
{
    private bool isHammerTaken = false;

    public Transform hammer;
    public Transform marioCapsule;
    private float marioXAxis = 0;
    private float marioYAxis = 0;
    private float marioZAxis = 0;
    private int timer = 1;
    private int timerStack = 0;
    public ParticleSystem dust;
    private bool setHammerPos = true;
    public GameObject Hammer;
    public static bool returnToNormal = false;

    void Start()
    {
        dust.Stop();
    }


    void Update()
    {
        marioXAxis = MarioCapsuleController.playerXAxis;
        marioYAxis = MarioCapsuleController.playerYAxis;
        marioZAxis = MarioCapsuleController.playerZAxis;

        isHammerTaken = Jump.isHammerTaken;

        if (isHammerTaken)
        {
            Destroy(GetComponent<Collider>());
            hammer.transform.SetParent(marioCapsule.transform.parent);

            if (setHammerPos)
            {
                transform.localPosition = new Vector3(marioXAxis, marioYAxis - 3f, marioZAxis);
                setHammerPos = false;
            }

            if (timerStack < 44)
            {
                if (timer > 0 && timer < 15)
                {
                    transform.eulerAngles = new Vector3(-45, transform.eulerAngles.y, transform.eulerAngles.z);
                    timer += 1;
                }
                if (timer == 15)
                {
                    timer = 0;
                }
                if (timer <= 0 && timer > -15)
                {
                    if (timer == 0)
                    {
                        dust.Play();
                    }
                    transform.eulerAngles = new Vector3(45, transform.eulerAngles.y, transform.eulerAngles.z);
                    timer -= 1;
                }
                if (timer == -15)
                {
                    timer = 1;
                    timerStack += 1;
                }
                if (timer == -7)
                {
                    dust.Stop();
                }
            }
            else if(timerStack >= 44)
            {
                Destroy(Hammer);
                returnToNormal = true;
            }
        }
        else
        {
            returnToNormal = false;
        }
    }
}
