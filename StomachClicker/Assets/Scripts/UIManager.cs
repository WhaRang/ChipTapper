using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
public enum Content
{
    SCORE,
    SHOP
}*/

public class UIManager : MonoBehaviour
{

    /*public Text scoreText;

    private void Update()
    {
        scoreText.text = ScoreManager.manager.getScore().ToString();
    }
*/
    /*public static UIManager manager;

    public Content[] content;
    public Text scoreText;

    private int currentPage;
    private float currentPageY;

    private void Awake()
    {
        if (manager == null)
            manager = this.gameObject.GetComponent<UIManager>();
    }

    private void Start()
    {
        if (HorizontalSwiper.swiper != null)
        {
            InitializeUIManager();
        }
        else
        {
            currentPage = -1;
        }
    }

    private void Update()
    {
        if (HorizontalSwiper.swiper != null)
        {
            if (currentPage == -1)
            {
                InitializeUIManager();
            }
            if (HorizontalSwiper.swiper.currentPage != currentPage)
            {
                pageChanged();
            }
            if (content[currentPage - 1] == Content.SCORE)
            {
                scoreText.text = ScoreManager.manager.getScore().ToString();
            }
        }        
    }

    private void pageChanged()
    {
        Vector3 newPosition = SwipeManager.manager.panels[currentPage - 1].transform.position;
        newPosition.y = currentPageY;
        SwipeManager.manager.panels[currentPage - 1].transform.position = newPosition;

        currentPage = HorizontalSwiper.swiper.currentPage;
        currentPageY = SwipeManager.manager.panels[currentPage - 1].transform.position.y;

        switch (content[currentPage - 1])
        {
            case Content.SCORE:
                {
                    scoreText.text = ScoreManager.manager.getScore().ToString();
                    break;
                }
            case Content.SHOP:
                {
                    scoreText.text = "SHOP";
                    break;
                }
        }
    }

    private void InitializeUIManager()
    {
        currentPage = HorizontalSwiper.swiper.currentPage;
        currentPageY = SwipeManager.manager.panels[currentPage - 1].transform.position.y;
    }*/
}
