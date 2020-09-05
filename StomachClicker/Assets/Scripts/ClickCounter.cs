using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCounter : MonoBehaviour
{
    public static ClickCounter counter;

    const float MAX_DECREASE_PERCENT_IMPACT = 3.5f;
    const float MAX_INCREASE_PERCENT_IMPACT = 7.5f;

    int clicksPerformed = 0;
    int clicksNeeded;
    float scaler = 1.0f;

    public Text textField;

    //Color greenColor = new Color(0.0f, 0.831f, 0.486f, 1.0f);
    //Color yellowColor = new Color(0.996f, 0.976f, 0.0f, 1.0f);
    //Color redColor = new Color(0.831f, 0.0f, 0.0f, 1.0f);

    private void Awake()
    {
        if (counter == null)
            counter = this.gameObject.GetComponent<ClickCounter>();
    }

    private void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        if (clicksPerformed > (int)(1.5 * clicksNeeded))
        {
            //textField.color = redColor;
            textField.text = clicksPerformed + "/" + 2 * clicksNeeded;
            scaler = 1.0f;
        }
        else if (clicksPerformed > clicksNeeded)
        {
            //textField.color = yellowColor;
            textField.text = clicksPerformed + "/" + (int)(1.5 * clicksNeeded);
            scaler = 1.5f;
        }
        else if (clicksPerformed <= clicksNeeded)
        {
            //textField.color =  greenColor;
            textField.text = clicksPerformed + "/" + clicksNeeded;
            scaler = 2.0f;
        }        
    }

    int ComputeClicksNeeded()
    {
        return ComputeClicksNeededFor(TaskManager.manager.brainTaskManager)
            + ComputeClicksNeededFor(TaskManager.manager.heartTaskManager)
            + ComputeClicksNeededFor(TaskManager.manager.stomachTaskManager);
    }

    public float GetScaler()
    {
        return scaler;
    }

    int ComputeClicksNeededFor(SingleTaskManager organ)
    {
        double result = 0.0f;

        if (organ.currTask == SingleTaskManager.TaskType.SCORE)
        {
            result = organ.GetAimScore() / SingleTaskManager.DEFAULT_DELTA;
        }
        else
        {
            float aimPercent = organ.GetAimPercent();
            float currPercent = organ.health.GetCurrPercent();
            if (organ.currTask == SingleTaskManager.TaskType.MORE_THAN)
            {
                if (currPercent >= aimPercent)
                {
                    return 1;
                }
                result = (aimPercent - currPercent) / MAX_INCREASE_PERCENT_IMPACT;
            }
            else if (organ.currTask == SingleTaskManager.TaskType.LESS_THAN)
            {
                if (aimPercent >= currPercent)
                {
                    return 1;
                }
                result = (currPercent - aimPercent) / MAX_DECREASE_PERCENT_IMPACT;
            }
        }

        result = System.Math.Round(result);

        return (int)result;
    }

    public void ClickPerformed()
    {
        clicksPerformed++;
    }

    public void UpdateClicks() {
        clicksPerformed = 0;
        clicksNeeded = ComputeClicksNeeded();
    }
}
