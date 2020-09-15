using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    public Image image;

    public Sprite activeSprite;
    public Sprite inactiveSprite;

    public void ActivateFor(float pause)
    {
        StartCoroutine(PauseCoroutine(pause));
    }

    public void SetActive()
    {
        image.sprite = activeSprite;
    }

    public void SetInactive()
    {
        image.sprite = inactiveSprite;
    }

    IEnumerator PauseCoroutine(float pause)
    {
        SetActive();
        yield return new WaitForSeconds(pause);
        SetInactive();
    }
}
