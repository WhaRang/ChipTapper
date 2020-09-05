using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconsBehaviour : MonoBehaviour
{
    public PageSelectButton brainIcon;
    public PageSelectButton heartIcon;
    public PageSelectButton stomachIcon;

    private int currentPage;

    private void Start()
    {
        currentPage = HorizontalSwiper.swiper.currentPage;
    }

    private void Update()
    {
        if (currentPage != HorizontalSwiper.swiper.currentPage)
        {
            PageChanged();
        }
    }

    private void PageChanged()
    {
        brainIcon.SetInactive();
        heartIcon.SetInactive();
        stomachIcon.SetInactive();

        switch (currentPage)
        {
            case 1:
                {
                    brainIcon.SetActive();
                    break;
                }
            case 2:
                {
                    heartIcon.SetActive();
                    break;
                }
            case 3:
                {
                    stomachIcon.SetActive();
                    break;
                }
        }
    }
}
