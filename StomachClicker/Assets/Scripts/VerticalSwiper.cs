using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class VerticalSwiper : MonoBehaviour, IDragHandler, IEndDragHandler 
{
    private Vector3 panelLocation;
    private RectTransform panel;
    private Vector3 startPos;
    private float startOffsetY;
    private float startHight;

    public float easing = 0.25f;
    public float dragTolerance = 300.0f;

    public static VerticalSwiper swiper;

    private void Awake()
    {
        if (swiper == null)
            swiper = this.gameObject.GetComponent<VerticalSwiper>();
        panel = GetComponent<RectTransform>();
    }

    private void Start()
    {
        panelLocation.y = transform.position.y;
        startPos.y = panel.position.y;
        startHight = transform.position.y;
        startOffsetY = panel.offsetMin.y;
    }
    
    /*
    public void OnBeginDrag(PointerEventData data)
    {
        panelLocation.y = transform.position.y;
    }*/

    public void OnDrag(PointerEventData data)
    {
        float difference = data.pressPosition.y - data.position.y;
        if (!((!(difference <= 0) && transform.position.y <= startPos.y - dragTolerance) ||
                ((difference <= 0) && Math.Abs(panel.offsetMax.y) >= Math.Abs(startOffsetY) + dragTolerance)))
        {
            transform.position = panelLocation - new Vector3(0, difference, 0);
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        bool isUp = data.pressPosition.y < data.position.y;
        Vector3 newPosition;
        if (!isUp && transform.position.y <= startPos.y)
        {
            newPosition = startPos;
        }
        else if (isUp && Math.Abs(panel.offsetMax.y) >= Math.Abs(startOffsetY))
        {
            newPosition = transform.position;
            newPosition.y = -startHight;
        }
        else
        {
            newPosition = transform.position;
        }
        panelLocation = newPosition;
        StartCoroutine(SmoothMove(transform.position, newPosition, easing));
    }

    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}
