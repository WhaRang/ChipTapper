using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager manager;

    public SingleTaskManager brainTaskManager;
    public SingleTaskManager heartTaskManager;
    public SingleTaskManager stomachTaskManager;

    const int TASKS_NEEDED_FOR_FIRST_LEVEL = 5;
    const float DELTA_TASKS = 2f;
    const int START_SCORE = 8;
    const int DELTA_SCORE = 1;

    const int START_PERCENT = 50;
    const int DELTA_PERCENT = 5;
    const int SMALLEST_PERCENT = 10;
    const int BIGGEST_PERCENT = 90;

    const int BONUS_SCORE_FOR_LEVEL = 100;

    int level = 1;
    int tasksNeeded = TASKS_NEEDED_FOR_FIRST_LEVEL;
    int completedTasks = 0;

    private void Awake()
    {
        if (manager == null)
            manager = this.gameObject.GetComponent<TaskManager>();
    }

    void Start()
    {
        GenerateTaskForAll();
        PrintAllForTheFirstTime();
        LevelFill.instance.UpdateFill(completedTasks, tasksNeeded);
        ClickCounter.counter.UpdateClicks();
    }

    void Update()
    {
        if (EverybodyIsCompleted())
        {
            TasksCompleted();
        }
        if (AnyoneStarted())
        {
            StartAll();
        }
    }

    bool EverybodyIsCompleted()
    {
        return brainTaskManager.IsCompleted() &&
            heartTaskManager.IsCompleted() &&
            stomachTaskManager.IsCompleted();
    }

    bool AnyoneStarted()
    {
        return brainTaskManager.IsStarted() ||
            heartTaskManager.IsStarted() ||
            stomachTaskManager.IsStarted();
    }

    void StartAll()
    {
        brainTaskManager.SetStarted(true);
        heartTaskManager.SetStarted(true);
        stomachTaskManager.SetStarted(true);
    }

    void LevelCompleted()
    {
        AddBonusScoreForLevel();
        tasksNeeded = ComputeTasksNeededForNextLevel();
        completedTasks = 0;
        level++;
    }

    void TasksCompleted()
    {
        completedTasks++;
        if (completedTasks >= tasksNeeded)
        {
            LevelCompleted();
        }
        AddTimeDependingOnClicks();
        AddScoreDependingOnClicks();
        GenerateTaskForAll();
        PrintAllForTheFirstTime();
        LevelFill.instance.UpdateFill(completedTasks, tasksNeeded);
        ClickCounter.counter.UpdateClicks();
    }

    void AddTimeDependingOnClicks()
    {
        Timer.timer.AddTime(Timer.DEFAULT_TIME * ClickCounter.counter.GetScaler());
    }

    void AddScoreDependingOnClicks()
    {
        int scoreForTasks = ComputeScoreForOrgan(brainTaskManager)
            + ComputeScoreForOrgan(heartTaskManager)
            + ComputeScoreForOrgan(stomachTaskManager);
        ScoreManager.manager.AddScore(scoreForTasks * ClickCounter.counter.GetScaler());
    }

    void AddBonusScoreForLevel()
    {
        ScoreManager.manager.AddScore(level * BONUS_SCORE_FOR_LEVEL);
    }

    int ComputeScoreForOrgan(SingleTaskManager organ)
    {
        switch (organ.currTask)
        {
            case SingleTaskManager.TaskType.LESS_THAN:
                {
                    return 10 - (int)(organ.GetAimPercent() / 10);
                }
            case SingleTaskManager.TaskType.MORE_THAN:
                {
                    return (int)(organ.GetAimPercent() / 10);
                }
            case SingleTaskManager.TaskType.SCORE:
                {
                    return (int)(organ.GetAimScore() / 20);
                }
            default:
                {
                    return 0;
                }
        }
    }

    void PrintAllForTheFirstTime()
    {
        brainTaskManager.PrintStatsForTheFirstTime();
        heartTaskManager.PrintStatsForTheFirstTime();
        stomachTaskManager.PrintStatsForTheFirstTime();
    }

    void GenerateTaskForAll()
    {
        GenerateTask(brainTaskManager);
        GenerateTask(heartTaskManager);
        GenerateTask(stomachTaskManager);
    }

    void GenerateTask(SingleTaskManager manager)
    {
        int taskTypeIndex = Random.Range(0, 3);
        switch (taskTypeIndex)
        {
            case 0:
                {
                    int score = ComputeScoreForLevel();
                    manager.GenerateScoreTask(score);
                    break;
                }
            case 1:
                {
                    int percent = ComputeMoreThanForLevel();
                    manager.GenerateMoreThanTask(percent);
                    break;
                }
            case 2:
                {
                    int percent = ComputeLessThanForLevel();
                    manager.GenerateLessThanTask(percent);
                    break;
                }
        }
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetTasksNeeded()
    {
        return tasksNeeded;
    }

    public int GetCompletedTasks()
    {
        return completedTasks;
    }

    int ComputeTasksNeededForNextLevel()
    {
        return TASKS_NEEDED_FOR_FIRST_LEVEL + (int)(DELTA_TASKS * System.Math.Sqrt(level));
    }

    int ComputeScoreForLevel()
    {
        return  START_SCORE + (DELTA_SCORE * (int)System.Math.Round(System.Math.Sqrt(level - 1)));
    }

    int ComputeMoreThanForLevel()
    {
        int percent = START_PERCENT + (level * DELTA_PERCENT) / 2;
        return percent < BIGGEST_PERCENT ? percent : BIGGEST_PERCENT;
    }

    int ComputeLessThanForLevel()
    {
        int percent = START_PERCENT - (level * DELTA_PERCENT) / 2;
        return percent > SMALLEST_PERCENT ? percent : SMALLEST_PERCENT;
    }
}
