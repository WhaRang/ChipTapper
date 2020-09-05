using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager manager;

    public Text textField;
    int score;

    private void Awake()
    {
        if (manager == null)
            manager = this.gameObject.GetComponent<ScoreManager>();
    }

    private void Start()
    {
        textField.text = score + " pt.";
    }

    public void AddScore(float scoreToAdd)
    {
        score += (int)scoreToAdd;
        textField.text = score + " pt.";
    }
}
