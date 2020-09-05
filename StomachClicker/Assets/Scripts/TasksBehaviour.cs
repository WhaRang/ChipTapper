using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TasksBehaviour : MonoBehaviour
{
    int currLevel = 1;
    int completedTaskCounter = 0;
    int completedTaskGoal = 5;

    Color greenColor = new Color(0.0f, 0.831f, 0.486f, 1.0f);

    public Text brainText;
    public Text heartText;
    public Text stomachText;

    public int brainScore = 7;
    public int heartScore = 7;
    public int stomachScore = 7;

    bool isBrainCompleted = false;
    bool isHeartCompleted = false;
    bool isStomachCompleted = false;

    int brainGoal = 0;
    int heartGoal = 0;
    int stomachGoal = 0;

    int currBrain = 0;
    int currHeart = 0;
    int currStomach = 0;

    private void Start()
    {
        generateAll();   
    }

    private void Update()
    {
        printAll();
    }

    void printAll()
    {
        brainText.text = "Brain " + currBrain + "/" + brainGoal;
        heartText.text = "Heart " + currHeart + "/" + heartGoal;
        stomachText.text = "Stomach " + currStomach + "/" + stomachGoal;
    }

    void generateAll()
    {
        generateBrainTask();
        generateHeartTask();
        generateStomachTask();
    }

    public void brainClicked()
    {
        if (!isBrainCompleted)
        {
            currBrain += brainScore;
        }
        checkBrain();
    }

    public void heartClicked()
    {
        if (!isHeartCompleted)
        {
            currHeart += heartScore;
        }
        checkHeart();
    }

    public void stomachClicked()
    {
        if (!isStomachCompleted)
        {
            currStomach += stomachScore;
        }
        checkStomach();
    }

    void checkAll()
    {
        if (isBrainCompleted && isHeartCompleted && isStomachCompleted)
        {
            generateAll();
            falseAll();
            colorAllTextToBlack();
            checkCounter();
        }
    }

    void checkCounter()
    {
        completedTaskCounter++;
        if (completedTaskCounter >= completedTaskGoal)
        {
            currLevel++;
            completedTaskCounter = 0;
        }
    }

    void colorAllTextToBlack()
    {
        brainText.color = Color.black;
        heartText.color = Color.black;
        stomachText.color = Color.black;
    }

    void falseAll()
    {
        isBrainCompleted = false;
        isHeartCompleted = false;
        isStomachCompleted = false;
    }

    void checkBrain()
    {
        if (currBrain >= brainGoal)
        {
            isBrainCompleted = true;
            brainText.color = greenColor;
        }
        checkAll();
    }

    void checkHeart()
    {
        if (currHeart >= heartGoal)
        {
            isHeartCompleted = true;
            heartText.color = greenColor;
        }
        checkAll();
    }

    void checkStomach()
    {
        if (currStomach >= stomachGoal)
        {
            isStomachCompleted = true;
            stomachText.color = greenColor;
        }
        checkAll();
    }

    void generateBrainTask()
    {
        currBrain = 0;
        brainGoal = computeScoreGoal();
    }

    void generateHeartTask()
    {
        currHeart = 0;
        heartGoal = computeScoreGoal();
    }

    void generateStomachTask()
    {
        currStomach = 0;
        stomachGoal = computeScoreGoal();
    }

    int computeScoreGoal()
    {
        return currLevel * 4 * Random.Range(1, 3) + Random.Range(0, 5 * currLevel);
    }
}
