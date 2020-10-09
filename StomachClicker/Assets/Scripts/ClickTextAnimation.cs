using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickTextAnimation : MonoBehaviour
{
    public Text textField;
    public Image bg;

    Color defaultColor;

    const float DEFAULT_PAUSE = 0.3f;

    private void Start()
    {
        defaultColor = bg.color;
    }

    public void Animate()
    {
        StartCoroutine(BackToColorCoroutine());
    }

    IEnumerator BackToColorCoroutine()
    {
        TextAnimator.animator.ColorSwap(textField, bg, DEFAULT_PAUSE);
        yield return new WaitForSeconds(DEFAULT_PAUSE);
        bg.color = defaultColor;
    }
}
