using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonBehaviour : MonoBehaviour
{
    public Animator playButtonAnimator;

    public GameObject pauseMenu;
    public GameObject dumper;

    float animationTime = 0.1f;

    public void PressedDown()
    {
        playButtonAnimator.SetTrigger("Down");
    }

    public void PressedUp()
    {
        playButtonAnimator.SetTrigger("Up");
    }

    public void OnClick()
    {
        StartCoroutine(ClickCoroutine());
    }

    IEnumerator ClickCoroutine()
    {
        yield return new WaitForSeconds(animationTime);
        pauseMenu.SetActive(false);
        dumper.SetActive(false);
        Timer.timer.SetStopped(false);
    }
}
