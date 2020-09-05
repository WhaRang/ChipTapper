using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager manager;

    public GameObject shop;
    public GameObject menu;
    public GameObject main;

    private void Awake()
    {
        if (manager == null)
            manager = this.gameObject.GetComponent<PanelManager>();
    }

    public void EnableShop()
    {
        menu.SetActive(false);
        main.SetActive(false);
        shop.SetActive(true);
    }

    public void EnableMain()
    {
        menu.SetActive(false);
        shop.SetActive(false);
        main.SetActive(true);        
    }

    public void EnableMenu()
    {
        menu.SetActive(true);
        shop.SetActive(false);
        main.SetActive(false);
    }
}
