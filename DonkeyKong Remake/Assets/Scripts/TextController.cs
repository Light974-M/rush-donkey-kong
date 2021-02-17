using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{

    public TMP_Text TimerText;
    private int timer = 100;
    private int timerScale = 0;

    void Update()
    {
        if(!Jump.deathAnimationStart)
        {
            TimerText.text = timer.ToString();
            timerScale += 1;
        }

        //exploration = 120
        //normal = 60
        //hard = 45
        //pierre = 30
        if(timerScale >= 60)
        {
            timerScale = 0;
            timer -= 1;
        }
        

        if(timer <= 0)
        {
            Jump.deathAnimationStart = true;
        }
    }
}
