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
    public ClickTextAnimation textAnimation;

    bool isFirstTime = true;

    public Image multiplierIcon;

    public Sprite x1Sprite;
    public Sprite x2Sprite;
    public Sprite x1_5Sprite;

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
            textField.text = clicksPerformed + "/" + 2 * clicksNeeded;
            scaler = 1.0f;
            multiplierIcon.sprite = x1Sprite;
        }
        else if (clicksPerformed > clicksNeeded)
        {
            textField.text = clicksPerformed + "/" + (int)(1.5 * clicksNeeded);
            scaler = 1.5f;
            multiplierIcon.sprite = x1_5Sprite;
        }
        else if (clicksPerformed <= clicksNeeded)
        {
            textField.text = clicksPerformed + "/" + clicksNeeded;
            scaler = 2.0f;
            multiplierIcon.sprite = x2Sprite;
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
        if (!isFirstTime)
        {
            textAnimation.Animate();
        }
        else
        {
            isFirstTime = false;
        }
        clicksPerformed = 0;
        clicksNeeded = ComputeClicksNeeded();
    }
}
