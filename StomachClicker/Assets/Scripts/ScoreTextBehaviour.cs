﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextBehaviour : MonoBehaviour
{
    public bool showScoreText;

    public Text textField;

    void Update()
    {
        if (showScoreText)
        {
            textField.text = ("SCORE: " + ScoreManager.manager.GetScore() + " PT.");
        }
        else
        {
            textField.text = ScoreManager.manager.GetScore() + " PT.";
        }
    }
}
