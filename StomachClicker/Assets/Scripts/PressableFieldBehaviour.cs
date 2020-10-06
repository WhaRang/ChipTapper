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
        tapToPlay.shouldMove = true;
        animator.SetTrigger("In");
    }

    public void PressUp()
    {
        tapToPlay.shouldMove = false;
        animator.SetTrigger("Out");
    }

    public void OnClick()
    {
        tapToPlay.shouldMove = true;
        FindObjectOfType<AudioManager>().Play("scratch");
        FindObjectOfType<AudioManager>().Stop("main_menu_theme");
    }
}
