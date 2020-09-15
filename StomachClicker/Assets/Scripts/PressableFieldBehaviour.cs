using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableFieldBehaviour : MonoBehaviour
{
    public Animator animator;

    public TapToPlayBehaviour tapToPlay;

    public void StartGame()
    {
        GameStarter.starter.isStarted = true;
    }

    public void PressedDown()
    {
        tapToPlay.isPressed = true;
        animator.SetTrigger("In");
    }

    public void PressUp()
    {
        animator.SetTrigger("Out");
    }
}
