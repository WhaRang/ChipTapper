using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffButton : MonoBehaviour
{
    public bool isActive;
    public Text textField;


    public void OnPressDown()
    {
        isActive = !isActive;
        UpdateText();
    }

    public void SetIsActive(bool newValue)
    {
        isActive = newValue;
        UpdateText();
    }

    void UpdateText()
    {
        if (isActive)
        {
            textField.text = "on";
        }
        else
        {
            textField.text = "off";
        }
    }
}
