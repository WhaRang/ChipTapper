using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleTaskManager : MonoBehaviour
{
    public enum TaskType { 
        SCORE,
        MORE_THAN,
        LESS_THAN
    }

    int currScore;
    int aimScore;
    int deltaScore;

    public const int DEFAULT_DELTA = 9;

    float aimPercent;

    bool isCompleted;
    bool isStarted;
    public TaskType currTask;

    public Text taskText;
    public Health health;

    //Color greenColor = new Color(0.0f, 0.831f, 0.486f, 1.0f);

    void Start()
    {
        deltaScore = DEFAULT_DELTA;
        ColorToBlack();
    }

    private void Update()
    {
        if (!isCompleted && isStarted)
        {
            CheckCompletion();
        }
    }

    void ColorToBlack()
    {
        taskText.color = Color.black;
    }

    void MarkAsDone()
    {
        //taskText.color = greenColor;
        taskText.text = "DONE.";
    }

    public void PrintStats()
    {
        if (currTask == TaskType.SCORE)
        {
            taskText.text = currScore + "/" + aimScore;
        }
        else if (currTask == TaskType.LESS_THAN)
        {
            taskText.text = "<" + aimPercent + "%";
        }
        else if (currTask == TaskType.MORE_THAN)
        {
            taskText.text = ">" + aimPercent + "%";
        }
    }

    public float GetAimPercent()
    {
        return aimPercent;
    }

    public int GetAimScore()
    {
        return aimScore;
    }

    public void SetStarted(bool started)
    {
        isStarted = started;
    }

    public bool IsStarted()
    {
        return isStarted;
    }

    public void SetDeltaScore(int score)
    {
        deltaScore = score;
    }

    public void GenerateScoreTask(int score)
    {
        isCompleted = false;
        isStarted = false;
        aimScore = score;
        currScore = 0;
        currTask = TaskType.SCORE;
        ColorToBlack();
    }

    public void GenerateLessThanTask(float percent)
    {
        isCompleted = false;
        isStarted = false;
        aimPercent = percent;
        currTask = TaskType.LESS_THAN;
        ColorToBlack();
    }

    public void GenerateMoreThanTask(float percent)
    {
        isCompleted = false;
        isStarted = false;
        aimPercent = percent;
        currTask = TaskType.MORE_THAN;
        ColorToBlack();
    }

    public void OnClick()
    {
        isStarted = true;
        if (currTask == TaskType.SCORE && !isCompleted)
        {
            currScore += deltaScore;
        }
        PrintStats();
        CheckCompletion();
    }

    void CheckCompletion()
    {
        if (!isCompleted)
        {
            if (currTask == TaskType.SCORE)
            {
                isCompleted = (currScore >= aimScore);
            }
            else if (currTask == TaskType.LESS_THAN)
            {
                isCompleted = (health.GetCurrPercent() < aimPercent);
            }
            else if (currTask == TaskType.MORE_THAN)
            {
                isCompleted = (health.GetCurrPercent() > aimPercent);
            }
        }
        
        if (isCompleted)
        {
            MarkAsDone();
        }
    }

    public bool IsCompleted()
    {
        return isCompleted;
    }
}
