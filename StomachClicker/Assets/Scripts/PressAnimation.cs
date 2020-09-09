using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnimation : MonoBehaviour
{
    public Animator animator;

    public void PressDown()
    {
        animator.SetTrigger("Down");
    }

    public void PressUp()
    {
        animator.SetTrigger("Up");
    }
}
