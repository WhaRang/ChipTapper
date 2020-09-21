using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitDialogNoButton : MonoBehaviour
{
    public GameObject dialog;
    public GameObject dumper;

    public Animator dialogAnimator;

    float animationTime = 0.25f;

    public void OnClick()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    IEnumerator FadeOutCoroutine()
    {
        dialogAnimator.SetTrigger("Out");
        yield return new WaitForSeconds(animationTime);
        dialog.SetActive(false);
        dumper.SetActive(false);
    }
}
