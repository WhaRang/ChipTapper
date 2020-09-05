using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public Text textField;

    void Update()
    {
        textField.text = "LVL " + TaskManager.manager.GetLevel();
    }
}
