using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTabBGColorManager : MonoBehaviour
{

    private int currentPage;
    public Animator animator;

    public HorizontalSwiper swiper;

    private void Start()
    {
        currentPage = swiper.currentPage;
    }

    private void Update()
    {
        if (currentPage != swiper.currentPage)
        {
            int newPage = swiper.currentPage;
            
            switch (currentPage)
            {
                case 1:
                    {
                        if (newPage == 2)
                        {
                            animator.SetTrigger("BrainToHeart");
                        } 
                        else
                        {
                            animator.SetTrigger("BrainToStomach");
                        }
                        break;
                    }
                case 2:
                    {
                        if (newPage == 1)
                        {
                            animator.SetTrigger("HeartToBrain");
                        }
                        else
                        {
                            animator.SetTrigger("HeartToStomach");
                        }
                        break;
                    }
                case 3:
                    {
                        if (newPage == 2)
                        {
                            animator.SetTrigger("StomachToHeart");
                        }
                        else
                        {
                            animator.SetTrigger("StomachToBrain");
                        }
                        break;
                    }
            }

            currentPage = newPage;
        }
    }

}
