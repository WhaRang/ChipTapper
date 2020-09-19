using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainExitBehaviour : MonoBehaviour
{
    public Animator exitButtonAnimator;

    float animationTime = 0.18f;

    public void PressDown()
    {
        exitButtonAnimator.SetTrigger("Down");
    }

    public void PressUp()
    {
        exitButtonAnimator.SetTrigger("Up");
    }

    public void OnClick()
    {
        StartCoroutine(ClickCoroutine());
    }

    IEnumerator ClickCoroutine()
    {
        yield return new WaitForSeconds(animationTime);
        Application.Quit();
    }
}
