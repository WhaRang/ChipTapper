using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehaviour : MonoBehaviour
{
    public Animator pauseAnimator;

    public GameObject pauseMenu;
    public GameObject dumper;

    public void PressedDown()
    {
        pauseAnimator.SetTrigger("Down");
    }

    public void PressedUp()
    {
        pauseAnimator.SetTrigger("Up");
    }

    public void OnClick()
    {
        Timer.timer.SetStopped(true);
        dumper.SetActive(true);
        pauseMenu.SetActive(true);
    }
}
