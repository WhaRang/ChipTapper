using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainThemeStarter : MonoBehaviour
{
    static bool started;

    public void StartMainTheme()
    {
        if (!started)
        {
            FindObjectOfType<AudioManager>().Play("main_theme");
            started = true;
        }
    }
}
