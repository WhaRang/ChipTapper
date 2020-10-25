using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTextBehaviour : MonoBehaviour
{

    public bool showAllMoney;
    public bool showDna;
    public Text textField;

    void Update()
    {
        if (showAllMoney)
        {
            textField.text = "" + MoneyManager.manager.GetAllMoney();
        }
        else
        {
            textField.text = "" + MoneyManager.manager.GetMoneyInRound();
        }

        if (showDna)
        {
            textField.text += " dna";
        }
    }
}
