using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrgansIconsBehaviour : MonoBehaviour
{
    public Animator brainAnimator;
    public Animator heartAnimator;
    public Animator stomachAnimator;

    public Icon brainIcon;
    public Icon heartIcon;
    public Icon stomachIcon;

    float pause = 2.0f;
    float counter = 2.0f;

    int state = 1;

    void Update()
    {
        if (!GameStarter.starter.isStarted)
        {
            counter += Time.deltaTime;
            if (counter >= pause)
            {
                counter = 0.0f;
                HandlePause();
            }
        }
    }

    void HandlePause()
    {
        HandleIcon();
        HandleAnimation();
        HandleState();
    }

    void HandleIcon()
    {
        switch (state) {
            case 1:
                {
                    brainIcon.ActivateFor(pause);
                    break;
                }
            case 2:
                {
                    heartIcon.ActivateFor(pause);
                    break;
                }
            case 3:
                {
                    stomachIcon.ActivateFor(pause);
                    break;
                }
        }
    }

    void HandleAnimation()
    {
        switch (state)
        {
            case 1:
                {
                    brainAnimator.SetTrigger("Select");
                    break;
                }
            case 2:
                {
                    heartAnimator.SetTrigger("Select");
                    break;
                }
            case 3:
                {
                    stomachAnimator.SetTrigger("Select");
                    break;
                }
        }
    }

    void HandleState()
    {
        state++;
        if (state > 3)
        {
            state = 1;
        }
    }
}
