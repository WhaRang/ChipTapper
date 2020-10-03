using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDisabler : MonoBehaviour
{
    public Animator bgAnimator;

    public GameObject menu;
    public GameObject dumper;

    float animationTime = 0.16f;

    public void OnClick()
    {
        bgAnimator.SetTrigger("Out");
        StartCoroutine(ClickCoroutine());
    }

    IEnumerator ClickCoroutine()
    {
        yield return new WaitForSeconds(animationTime);
        menu.SetActive(false);
        dumper.SetActive(false);
    }
}
