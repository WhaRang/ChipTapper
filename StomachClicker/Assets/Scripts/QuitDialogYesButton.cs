using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitDialogYesButton : MonoBehaviour
{
    public Animator canvasAnimator;
    float animationTime = 0.83f;

    public void OnClick()
    {
        FindObjectOfType<AudioManager>().Stop("main_theme");
        StartCoroutine(ClickCoroutine());
    }

    IEnumerator ClickCoroutine()
    {
        canvasAnimator.SetTrigger("Out");
        yield return new WaitForSeconds(animationTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
