using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimator : MonoBehaviour
{
    public static TextAnimator animator;

    private void Awake()
    {
        if (animator == null)
            animator = this.gameObject.GetComponent<TextAnimator>();
    }

    public void TypewriteText(Text textField, string text, float pause)
    {
        StartCoroutine(PrintLetterCoroutine(textField, text, pause));
    }

    IEnumerator PrintLetterCoroutine(Text textField, string text, float pause)
    {
        foreach (char letter in text)
        {
            textField.text += letter;
            yield return new WaitForSeconds(pause);
        }
    }
}
