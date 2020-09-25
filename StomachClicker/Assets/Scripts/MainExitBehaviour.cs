using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainExitBehaviour : MonoBehaviour
{
    float animationTime = 0.18f;

    public void OnClick()
    {
        StartCoroutine(ClickCoroutine());
    }

    IEnumerator ClickCoroutine()
    {
        yield return new WaitForSeconds(animationTime);
        Application.Quit();
    }
}
