using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeManager : MonoBehaviour
{
/*
    private bool isVertical = false;
    private bool startDragging = false;

    public float scaleHorizToVert = 2f;    
    public static SwipeManager manager;
    public GameObject[] panels;

    private void Awake()
    {
        if (manager == null)
            manager = this.gameObject.GetComponent<SwipeManager>();
    }

    public void HandleBeginDrag(PointerEventData data)
    {
        if (isVertical)
        {
            VerticalSwiper.swiper.OnBeginVerticalDrag(data);
        }
    }

    public void OnDrag(PointerEventData data)
    {
        float diffX = data.pressPosition.x - data.position.x;
        float diffY = data.pressPosition.y - data.position.y;
        if (!startDragging)
        {
            if (scaleHorizToVert * Math.Abs(diffX) >= Math.Abs(diffY))
            {
                isVertical = false;                
            }
            else
            {
                isVertical = true;
            }
        }
        if (!startDragging)
        {
            HandleBeginDrag(data);
        }
        if (isVertical)
        {
            VerticalSwiper swiper = panels[HorizontalSwiper.swiper.currentPage - 1].GetComponent<VerticalSwiper>();
            if (swiper)
            {
                swiper.OnVerticalDrag(data);
            }
        } 
        else
        {            
            HorizontalSwiper.swiper.OnHorizontalDrag(data);
        }
        startDragging = true;
    }

    public void OnEndDrag(PointerEventData data)
    {
        startDragging = false;
        if (isVertical)
        {
            VerticalSwiper swiper = panels[HorizontalSwiper.swiper.currentPage - 1].GetComponent<VerticalSwiper>();
            if (swiper)
            {
                swiper.OnEndVerticalDrag(data);
            }
        }
        else
        {
            HorizontalSwiper.swiper.OnEndHorizontalDrag(data);
        }
    }*/
}
