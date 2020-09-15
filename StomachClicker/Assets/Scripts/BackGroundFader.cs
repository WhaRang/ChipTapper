using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundFader : MonoBehaviour
{
    public Animator brainAnimator;
    public Animator heartAnimator;
    public Animator stomachAnimator;

    int stage = 1;
    float pause = 2.0f;
    float counter = 0.0f;

    void Update()
    {
        if (!GameStarter.starter.isStarted)
        {
            counter += Time.deltaTime;
            if (counter >= pause)
            {
                HandleStage();
                counter = 0.0f;
            }
        }
    }

    void HandleStage()
    {
        if (stage == 1)
        {
            brainAnimator.SetTrigger("Out");
            heartAnimator.SetTrigger("In");
        }
        else if (stage == 2)
        {            
            heartAnimator.SetTrigger("Out");
            stomachAnimator.SetTrigger("In");
        }
        else if (stage == 3)
        {
            stomachAnimator.SetTrigger("Out");
            brainAnimator.SetTrigger("In");
        }

        stage++;
        if (stage > 3)
        {
            stage = 1;
        }
    }
}
