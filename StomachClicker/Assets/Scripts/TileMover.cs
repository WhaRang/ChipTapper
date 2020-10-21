using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileMover : MonoBehaviour
{
    public static TileMover mover;

    private Vector3 panelLocation;
    private Vector3 tileLocation;
    private GameObject tileHolder;

    float menuToTileScaler;
    public static float DEFAULT_DELTA_WIDTH = 650.0f;
    
    public float percentThreshold = 0.2f;
    public float easing = 0.25f;
    public int totalPages = 3;
    public int currentPage = 1;

    private void Awake()
    {
        if (mover == null)
            mover = this.gameObject.GetComponent<TileMover>();
    }

    void Start()
    {
        menuToTileScaler = DEFAULT_DELTA_WIDTH / HorizontalSwiper.DEFAULT_SCREEN_SIZE;

        tileHolder = gameObject;
        panelLocation = transform.position;
        tileLocation = transform.position;
    }

    public void MovingOnDrag(PointerEventData data)
    {
        float difference = data.pressPosition.x - data.position.x;
        transform.position = panelLocation - new Vector3(difference * menuToTileScaler, 0, 0);
        tileHolder.transform.position = tileLocation - new Vector3(difference * menuToTileScaler, 0, 0);
    }

    public void MovingOnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) /
            (HorizontalSwiper.DEFAULT_SCREEN_SIZE * HorizontalSwiper.swiper.scaler);
        if (Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if (percentage > 0 && currentPage < totalPages)
            {
                currentPage++;
                newLocation += new Vector3(-HorizontalSwiper.DEFAULT_SCREEN_SIZE * HorizontalSwiper.swiper.scaler * menuToTileScaler, 0, 0);
            }
            else if (percentage < 0 && currentPage > 1)
            {
                currentPage--;
                newLocation += new Vector3(HorizontalSwiper.DEFAULT_SCREEN_SIZE * HorizontalSwiper.swiper.scaler * menuToTileScaler, 0, 0);
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
            tileLocation = newLocation;
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

    public void MoveTo(int page)
    {
        Vector3 newLocation = panelLocation;
        newLocation += new Vector3(HorizontalSwiper.DEFAULT_SCREEN_SIZE *
            HorizontalSwiper.swiper.scaler * menuToTileScaler * (currentPage - page), 0, 0);
        currentPage = page;
        StartCoroutine(SmoothMove(transform.position, newLocation, easing));
        panelLocation = newLocation;
        tileLocation = newLocation;
    }
}
