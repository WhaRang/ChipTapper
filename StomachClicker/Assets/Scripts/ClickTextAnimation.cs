using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickTextAnimation : MonoBehaviour
{
    public Text textField;
    public Image bg;

    const float DEFAULT_PAUSE = 0.3f;

    public void Animate()
    {
        TextAnimator.animator.ColorSwap(textField, bg, DEFAULT_PAUSE);
    }
}
