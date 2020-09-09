using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public const float DEFAULT_TIME = 4.0f;

    public static Timer timer;

    float startTime = 60.0f;
    public Text textField;

    bool isFirstClickPerformed;

    private void Awake()
    {
       if (timer == null)
            timer = this.gameObject.GetComponent<Timer>();
    }

    public void FirstClickPerformed()
    {
        isFirstClickPerformed = true;
    }

    void Update()
    {
        if (!EndGameManager.manager.IsEnded())
        {
            if (isFirstClickPerformed)
            {
                if (startTime < Time.deltaTime)
                {
                    startTime = 0.0f;
                    EndGameManager.manager.EndGame();
                }
                else
                {
                    startTime -= Time.deltaTime;
                }
                textField.text = startTime.ToString("F1") + "s";
            }
        }
        else
        {
            textField.text = "YOU LOSE";
        }
    }

    public void AddDefaultTime()
    {
        AddTime(DEFAULT_TIME);
    }

    public void AddTime(float time)
    {
        startTime += time;
    }
}
