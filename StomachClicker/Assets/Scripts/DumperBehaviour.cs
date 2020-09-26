using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumperBehaviour : MonoBehaviour
{
    public Animator animator;

    public void EndGame()
    {
        FindObjectOfType<AudioManager>().Stop("main_theme");
        FindObjectOfType<AudioManager>().Play("game_over");
        animator.SetTrigger("EndGame");
    }
}
