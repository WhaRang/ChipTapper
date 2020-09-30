using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainThemeStarter : MonoBehaviour
{
    static bool started;

    private void Start()
    {
        started = false;
    }

    public void StartMainTheme()
    {
        if (!started)
        {
            FindObjectOfType<AudioManager>().Play("main_theme");
            started = true;
        }
    }
}
