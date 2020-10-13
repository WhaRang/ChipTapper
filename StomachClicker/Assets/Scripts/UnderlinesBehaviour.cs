using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderlinesBehaviour : MonoBehaviour
{

    public int currentPage = 1;
    public GameObject[] underlines;

    float animationTime = 0.2f;

    private void Update()
    {
        if (currentPage != HorizontalSwiper.swiper.currentPage)
        {
            DisableUnderline(currentPage - 1);
            currentPage = HorizontalSwiper.swiper.currentPage;
            EnableUnderLine(currentPage - 1);
        }
    }

    void EnableUnderLine(int index)
    {
        underlines[index].SetActive(true);
    }

    void DisableUnderline(int index)
    {
        StartCoroutine(SmoothDisabling(underlines[index], animationTime, index + 1));
    }

    IEnumerator SmoothDisabling(GameObject gObj, float pause, int requiredPage)
    {
        if (gObj.GetComponent<Animator>() != null)
        {
            gObj.GetComponent<Animator>().SetTrigger("Out");
        }
        yield return new WaitForSeconds(pause);
        if (currentPage != requiredPage)
        {
            gObj.SetActive(false);
        }
        else
        {
            if (gObj.GetComponent<Animator>() != null)
            {
                gObj.GetComponent<Animator>().SetTrigger("In");
            }
        }
    }

}
