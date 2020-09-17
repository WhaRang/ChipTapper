using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundBehaviour : MonoBehaviour
{
    public enum Page { 
        FIRST,
        SECOND
    }

    public Page page;

    float speed;
    float minSpeed = 280.0f;
    float maxSpeed = 1140f;
    float speedDecrease = 5.0f;
    Vector2 direction = new Vector2(0.0f, 1.0f);

    bool isStarted;
    int currentPage;

    float alpha = 0.702f;
    float pause = 0.3f;
    int smoothness = 20;

    Color transparentColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    Color standartColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    public Image brainBG;
    public Image heartBG;
    public Image stomachBG;

    float deltaHeight = 2160.0f;

    /*private void Awake()
    {
        if (page == Page.FIRST)
        {
            this.gameObject.transform.position = Vector3.zero;
        }
        else if (page == Page.SECOND)
        {
            this.gameObject.transform.position = new Vector3(0.0f, -deltaHeight, 0.0f);
        }
    }*/

    private void Start()
    {
        standartColor.a = alpha;
        speed = minSpeed;
        maxSpeed = deltaHeight / 2;
        currentPage = HorizontalSwiper.swiper.currentPage;
    }

    public void StartMovement()
    {
        isStarted = true;
    }

    private void Update()
    {
        if (speed - speedDecrease >= minSpeed)
        {
            speed -= speedDecrease;
        }
        else
        {
            speed = minSpeed;
        }

        if (isStarted)
        {
            moveObject();
            if (this.gameObject.transform.position.y >= deltaHeight)
            {
                this.gameObject.transform.position = new Vector3(0.0f, -deltaHeight, 0.0f);
            }            
        }

        if (currentPage != HorizontalSwiper.swiper.currentPage)
        {
            HandlePage();
        }
    }

    public void StopBG()
    {
        minSpeed = 0.0f;
        speed = 0.0f;
    }

    void HandlePage()
    {
        DisableCurrent();
        currentPage = HorizontalSwiper.swiper.currentPage;
        EnableCurrent();
    }

    void EnableCurrent()
    {
        if (currentPage == 1)
        {
            StartCoroutine(EnableCoroutine(brainBG));
            StartCoroutine(SetAlphaAfterPause(brainBG, alpha));
        }
        else if (currentPage == 2)
        {
            StartCoroutine(EnableCoroutine(heartBG));
            StartCoroutine(SetAlphaAfterPause(heartBG, alpha));
        }
        else if (currentPage == 3)
        {
            StartCoroutine(EnableCoroutine(stomachBG));
            StartCoroutine(SetAlphaAfterPause(stomachBG, alpha));
        }
    }

    IEnumerator EnableCoroutine(Image image)
    {
        Color currentColor = transparentColor;
        float deltaAlpha = alpha / smoothness;
        float deltaPause = pause / smoothness;
        for (int i = 0; i < smoothness; i++)
        {
            currentColor.a += deltaAlpha;
            image.color = currentColor;
            yield return new WaitForSeconds(deltaPause);
        }
    }

    void DisableCurrent()
    {
        if (currentPage == 1)
        {
            StartCoroutine(DisableCoroutine(brainBG));
            StartCoroutine(SetAlphaAfterPause(brainBG, 0.0f));
        }
        else if (currentPage == 2)
        {
            StartCoroutine(DisableCoroutine(heartBG));
            StartCoroutine(SetAlphaAfterPause(heartBG, 0.0f));
        }
        else if (currentPage == 3)
        {
            StartCoroutine(DisableCoroutine(stomachBG));
            StartCoroutine(SetAlphaAfterPause(heartBG, 0.0f));
        }
    }

    IEnumerator DisableCoroutine(Image image)
    {
        Color currentColor = image.color;
        float deltaAlpha = alpha / smoothness;
        float deltaPause = pause / smoothness;
        for (int i = 0; i < smoothness; i++)
        {
            if (currentColor.a < deltaAlpha)
            {
                currentColor.a = 0.0f;
            } 
            else
            {
                currentColor.a -= deltaAlpha;
            }
            image.color = currentColor;
            yield return new WaitForSeconds(deltaPause);
        }
    }

    IEnumerator SetAlphaAfterPause(Image image, float aimAlpha)
    {
        yield return new WaitForSeconds(pause);
        Color newColor = image.color;
        newColor.a = aimAlpha;
        image.color = newColor;
    }

    void moveObject()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void AddSpeed(float deltaSpeed)
    {
        speed += deltaSpeed;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}
