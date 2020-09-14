using System.Collections;
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
    int deltaScore = DEFAULT_DELTA;

    public const int DEFAULT_DELTA = 1;
    const float DEFAULT_JUMP_PAUSE = 0.2f;
    const float DEFAULT_JUMP_HEIGHT = 10f;
    const float DEFAULT_TYPEWRITER_PAUSE = 0.02f;

    float aimPercent;

    bool isCompleted;
    bool isMarked;
    bool isStarted;
    bool isFirstTime = true;

    public TaskType currTask;

    public Text taskText;
    public Text doneText;

    public Health health;

    //Color greenColor = new Color(0.0f, 0.831f, 0.486f, 1.0f);

    private void Update()
    {
        if (!isCompleted && isStarted)
        {
            CheckCompletion();
        }
    }

    void MarkAsDone()
    {
        doneText.text = "";
        SetDoneTextActive();
        TextAnimator.animator.TypewriteText(doneText, "DONE.", DEFAULT_TYPEWRITER_PAUSE);
    }

    void SetDoneTextActive()
    {
        taskText.gameObject.SetActive(false);
        doneText.gameObject.SetActive(true);
    }

    void SetTaskTextActive()
    {
        doneText.gameObject.SetActive(false);
        taskText.gameObject.SetActive(true);
    }

    IEnumerator PrintStatsWithPause(float pause)
    {
        yield return new WaitForSeconds(pause);
        SetTaskTextActive();
        PrintStats();
        TextAnimator.animator.HalfJump(taskText, DEFAULT_JUMP_HEIGHT, DEFAULT_JUMP_PAUSE);
    }

    public void PrintStatsForTheFirstTime()
    {
        if (!isFirstTime)
        {
            StartCoroutine(PrintStatsWithPause(5 * DEFAULT_TYPEWRITER_PAUSE));
        }
        else
        {
            SetTaskTextActive();
            PrintStats();
            isFirstTime = false;
        }
    }

    public void PrintStats()
    {
        if (isCompleted)
        {
            return;
        }

        Print();
    }

    void Print()
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
    }

    public void GenerateLessThanTask(float percent)
    {
        isCompleted = false;
        isStarted = false;
        aimPercent = percent;
        currTask = TaskType.LESS_THAN;
    }

    public void GenerateMoreThanTask(float percent)
    {
        isCompleted = false;
        isStarted = false;
        aimPercent = percent;
        currTask = TaskType.MORE_THAN;
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

            isMarked = false;
        }

        if (isCompleted && !isMarked)
        {
            isMarked = true;
            MarkAsDone();
        }
    }

    public bool IsCompleted()
    {
        return isCompleted;
    }
}
