using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreNullifier : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetFloat("highscore", 1.0f);
        PlayerPrefs.Save();
    }
}
