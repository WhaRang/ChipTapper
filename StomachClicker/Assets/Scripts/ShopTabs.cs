using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTabs : MonoBehaviour
{
    public GameObject[] tabs;

    public void EnableTab(int index)
    {

        for (int i = 0; i < tabs.Length; i++)
        {
            if (index == i)
            {
                tabs[i].SetActive(true);
            }
            else
            {
                tabs[i].SetActive(false);
            }
        }
    }
}
