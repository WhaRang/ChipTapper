using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumperBehaviour : MonoBehaviour
{
    public Animator animator;

    public void EndGame()
    {
        animator.SetTrigger("EndGame");
    }
}
