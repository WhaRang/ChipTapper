using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextButtonBehaviour : MonoBehaviour
{
    public Animator exitButtonAnimator;

    public void PressDown()
    {
        exitButtonAnimator.SetTrigger("Down");
    }

    public void PressUp()
    {
        exitButtonAnimator.SetTrigger("Up");
    }
}
