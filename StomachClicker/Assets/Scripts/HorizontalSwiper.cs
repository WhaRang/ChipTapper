using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HorizontalSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public static HorizontalSwiper swiper;

    private Vector3 panelLocation;
    private Vector3 bgLocation;
    private GameObject bgHolder;

    public float percentThreshold = 0.2f;
    public float easing = 0.25f;
    public int totalPages = 3;
    public int currentPage = 1;

    private void Awake()
    {
        if (swiper == null)
            swiper = this.gameObject.GetComponent<HorizontalSwiper>();
    }

    void Start()
    {
        bgHolder = gameObject;
        panelLocation = transform.position;
        bgLocation = transform.position;
    }
    public void OnDrag(PointerEventData data)
    {
        float difference = data.pressPosition.x - data.position.x;
        transform.position = panelLocation - new Vector3(difference, 0, 0);
        bgHolder.transform.position = bgLocation - new Vector3(difference, 0, 0);
    }
    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if (Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if (percentage > 0 && currentPage < totalPages)
            {
                currentPage++;
                newLocation += new Vector3(-Screen.width, 0, 0);
            }
            else if (percentage < 0 && currentPage > 1)
            {
                currentPage--;
                newLocation += new Vector3(Screen.width, 0, 0);
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
            bgLocation = newLocation;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
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

    public void SetPage(int page)
    {
        if (page < 1 || page > totalPages)
        {
            return;
        }

        currentPage = page;

        Vector3 newLocation = Vector3.zero;
        newLocation.x = (-1) * (page - 1) * Screen.width;

        panelLocation = newLocation;
        bgLocation = newLocation;
        transform.position = newLocation;
    }
}