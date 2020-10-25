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

    public void TextColorSwap(Text textField, Color secondColor, float pause)
    {
        StartCoroutine(TextColorSwapCoroutine(textField, secondColor, pause));
    }

    IEnumerator TextColorSwapCoroutine(Text textField, Color secondColor, float pause)
    {
        Color originalTextColor = textField.color;
        textField.color = secondColor;
        yield return new WaitForSeconds(pause);
        textField.color = originalTextColor;
    }

    public void ColorSwap(Text textField, Image bg, float pause)
    {
        StartCoroutine(ColorSwapCoroutine(textField, bg, pause));
    }

    IEnumerator ColorSwapCoroutine(Text textField, Image bg, float pause)
    {
        Color originalTextColor = textField.color;
        textField.color = bg.color;
        bg.color = originalTextColor;
        yield return new WaitForSeconds(pause);
        bg.color = textField.color;
        textField.color = originalTextColor;
    }

    public void HalfJump(GameObject gObject, float jump, float pause)
    {
        StartCoroutine(JumpCoroutine(gObject, jump, pause));
    }

    IEnumerator JumpCoroutine(GameObject gObject, float jump, float pause)
    {
        if (gObject != null)
            gObject.transform.position += new Vector3(0f, jump / 2, 0f);
        yield return new WaitForSeconds(pause / 3);
        if (gObject != null)
            gObject.transform.position += new Vector3(0f, jump / 2, 0f);
        yield return new WaitForSeconds(pause / 3);
        if (gObject != null)
            gObject.transform.position -= new Vector3(0f, jump / 2, 0f);
        yield return new WaitForSeconds(pause / 3);
        if (gObject != null)
            gObject.transform.position -= new Vector3(0f, jump / 2, 0f);
    }

    public void TypewriteText(Text textField, string text, float pause)
    {
        StartCoroutine(TypewriterCoroutine(textField, text, pause));
    }

    IEnumerator TypewriterCoroutine(Text textField, string text, float pause)
    {
        foreach (char letter in text)
        {
            textField.text += letter;
            yield return new WaitForSeconds(pause);
        }
    }
}
