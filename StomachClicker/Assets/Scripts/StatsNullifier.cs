using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsNullifier : MonoBehaviour
{
    void Start()
    {
        ScoreManager.manager.ZeroScore();
        MoneyManager.manager.ZeroMoney();
    }
}
