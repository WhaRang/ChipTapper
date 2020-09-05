using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageSelectButton : MonoBehaviour
{
    public Image icon;
    public Sprite iconInactive;
    public Sprite iconActive;

    private bool isActive;
    public int targetPage;

    public void Update()
    {
        if (targetPage == HorizontalSwiper.swiper.currentPage)
        {
            SetActive();
        }
        else
        {
            SetInactive();
        }
    }

    public void Select()
    {
        HorizontalSwiper.swiper.SetPage(targetPage);
    }

    public void SetActive()
    {
        isActive = true;
        icon.sprite = iconActive;
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
