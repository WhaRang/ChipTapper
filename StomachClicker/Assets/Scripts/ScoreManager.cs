using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager manager;
    static int score;
    static int highScore;

    private void Awake()
    {
        if (manager == null)
            manager = this.gameObject.GetComponent<ScoreManager>();
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", highScore);
    }

    private void Update()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
        }
    }

    public void AddScore(float scoreToAdd)
    {
        score += (int)scoreToAdd;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void ZeroScore()
    {
        score = 0;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("highscore", highScore);
        PlayerPrefs.Save();
    }
}
