using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WiresBehaviour : MonoBehaviour
{
    public PageSelectButton brainButton;
    public PageSelectButton heartButton;
    public PageSelectButton stomachButton;

    public Image brainWire;
    public Image heartWire;
    public Image stomachWire;

    Color greenColor = new Color(0.0f, 0.831f, 0.486f, 1.0f);
    Color greyColor = new Color(0.831f, 0.831f, 0.831f, 0.78125f);

    private void Update()
    {
        if (brainButton.IsActive())
        {
            SetFirstActive();
        }
        if (heartButton.IsActive())
        {
            SetSecondActive();
        }
        if (stomachButton.IsActive())
        {
            SetThirdActive();
        }
    }

    void SetFirstActive()
    {
        brainWire.color = greenColor;
        heartWire.color = greyColor;
        stomachWire.color = greyColor;
    }

    void SetSecondActive()
    {
        brainWire.color = greyColor;
        heartWire.color = greenColor;
        stomachWire.color = greyColor;
    }

    void SetThirdActive()
    {
        brainWire.color = greyColor;
        heartWire.color = greyColor;
        stomachWire.color = greenColor;
    }
}
