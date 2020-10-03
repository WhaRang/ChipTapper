using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEnabler : MonoBehaviour
{
    public GameObject menu;
    public GameObject dumper;

    public void OnClick()
    {
        dumper.SetActive(true);
        menu.SetActive(true);
    }
}
