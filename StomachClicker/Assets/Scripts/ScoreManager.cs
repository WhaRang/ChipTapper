using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager manager;
    static int score;

    private void Awake()
    {
        if (manager == null)
            manager = this.gameObject.GetComponent<ScoreManager>();
    }

    public void AddScore(float scoreToAdd)
    {
        score += (int)scoreToAdd;
    }

    public int GetScore()
    {
        return score;
    }

    public void ZeroScore()
    {
        score = 0;
    }
}
