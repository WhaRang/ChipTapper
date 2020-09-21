using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonBehaviour : MonoBehaviour
{
    public Animator exitButtonAnimator;

    public GameObject dialog;
    public GameObject dumper;

    public void PressDown()
    {
        exitButtonAnimator.SetTrigger("Down");
    }

    public void PressUp()
    {
        exitButtonAnimator.SetTrigger("Up");
    }

    public void OnClick()
    {
        dumper.SetActive(true);
        dialog.SetActive(true);
    }
}
