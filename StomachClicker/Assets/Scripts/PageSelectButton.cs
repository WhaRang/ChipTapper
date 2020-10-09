using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageSelectButton : MonoBehaviour
{
    public GameObject organHolder;
    public GameObject currOrgan;

    public Image icon;
    public Sprite iconInactive;
    public Sprite iconActive;

    public PageSelectButton firstButton;
    public PageSelectButton secondButton;

    public bool isActive;

    [Range(0, 2)]
    public int currPage;

    Vector3 newPostion;
    float pageWidth;

    private void Start()
    {
        pageWidth = Screen.width;
        newPostion = organHolder.transform.position;
        newPostion.x = currPage * pageWidth;
        currOrgan.transform.position = newPostion;
        newPostion.x = -currPage * pageWidth;
        if (isActive)
        {
            Select();
        }
    }

    public void Select()
    {
        newPostion.y = organHolder.transform.position.y;
        SetActive();
        firstButton.SetInactive();
        secondButton.SetInactive();
        organHolder.transform.position = newPostion;
    }

    public void SetActive()
    {
        isActive = true;
        icon.sprite = iconActive;
        PageManager.manager.currPage = currPage;
    }

    public void SetInactive()
    {
        isActive = false;
        icon.sprite = iconInactive;
    }

    public bool IsActive()
    {
        return isActive;
    }
}
