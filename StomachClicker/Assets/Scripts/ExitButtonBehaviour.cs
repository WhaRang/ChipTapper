using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonBehaviour : MonoBehaviour
{
    public Animator exitButtonAnimator;
    public GameObject dialogPrefab;

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
        Instantiate(dialogPrefab, Vector3.zero, Quaternion.identity,
            GameObject.FindGameObjectWithTag("Canvas").transform);
    }
}
