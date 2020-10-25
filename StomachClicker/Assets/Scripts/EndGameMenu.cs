using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMenu : MonoBehaviour
{
    public GameObject newRecordCaption;

    void Update()
    {
        if (ScoreManager.manager.isHighScore)
        {
            newRecordCaption.SetActive(true);
        }
    }
}
