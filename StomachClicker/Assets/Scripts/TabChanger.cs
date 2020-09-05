using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabChanger : MonoBehaviour
{

    public GameObject GameTab;
    public GameObject ContractTab;
    public GameObject PauseTab;


    public void ActivateGameTab()
    {
        GameTab.SetActive(true);
        ContractTab.SetActive(false);
        PauseTab.SetActive(false);
    }

    public void ActivateContractTab()
    {
        GameTab.SetActive(false);
        ContractTab.SetActive(true);
        PauseTab.SetActive(false);
    }

    public void ActivatePauseTab()
    {
        GameTab.SetActive(false);
        ContractTab.SetActive(false);
        PauseTab.SetActive(true);
    }
}
