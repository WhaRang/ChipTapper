using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class OnOffButton : MonoBehaviour
{
    public bool isActive;
    Text textField;

    private void Start()
    {
        textField = GetComponent<Text>();
    }

    public void OnPressDown()
    {
        isActive = !isActive;
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
