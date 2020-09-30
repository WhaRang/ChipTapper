using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTextBehaviour : MonoBehaviour
{
    public bool showScoreText;

    public Text textField;

    void Update()
    {
        if (showScoreText)
        {
            textField.text = ("HIGHSCORE: " + ScoreManager.manager.GetHighScore() + " PT.");
        }
        else
        {
            textField.text = ScoreManager.manager.GetHighScore() + " PT.";
        }
    }
}
