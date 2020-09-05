using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    public PageSelectButton brainButton;
    public PageSelectButton heartButton;
    public PageSelectButton stomachButton;

    public Animator brainLightAnimator;
    public Animator heartLightAnimator;
    public Animator stomachLightAnimator;

    bool isBrainActive;
    bool isHeartActive;
    bool isStomachActive;

    private void Update()
    {
        if (brainButton.IsActive())
        {
            SetFirstActive();
        }
        if (heartButton.IsActive())
        {
            SetSecondActive();
        }
        if (stomachButton.IsActive())
        {
            SetThirdActive();
        }
    }

    void SetFirstActive()
    {
        if (isBrainActive)
        {
            return;
        }

        if (isHeartActive)
        {
            heartLightAnimator.SetTrigger("Out");
        }

        if (isStomachActive)
        {
            stomachLightAnimator.SetTrigger("Out");
        }

        brainLightAnimator.SetTrigger("In");

        isBrainActive = true;
        isHeartActive = false;
        isStomachActive = false;
    }

    void SetSecondActive()
    {
        if (isHeartActive)
        {
            return;
        }

        if (isBrainActive)
        {
            brainLightAnimator.SetTrigger("Out");
        }

        if (isStomachActive)
        {
            stomachLightAnimator.SetTrigger("Out");
        }

        heartLightAnimator.SetTrigger("In");

        isBrainActive = false;
        isHeartActive = true;
        isStomachActive = false;
    }

    void SetThirdActive()
    {
        if (isStomachActive)
        {
            return;
        }

        if (isHeartActive)
        {
            heartLightAnimator.SetTrigger("Out");
        }

        if (isBrainActive)
        {
            brainLightAnimator.SetTrigger("Out");
        }

        stomachLightAnimator.SetTrigger("In");

        isBrainActive = false;
        isHeartActive = false;
        isStomachActive = true;
    }
}
