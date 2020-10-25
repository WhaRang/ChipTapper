using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager manager;

    static int moneyInRound;
    static int allMoney;

    private void Awake()
    {
        if (manager == null)
            manager = this.gameObject.GetComponent<MoneyManager>();
    }

    private void Start()
    {
        allMoney = PlayerPrefs.GetInt("allMoney", 0);
    }

    public void AddMoney(float moneyToAdd)
    {
        moneyInRound += (int)moneyToAdd;
        allMoney += (int)moneyToAdd;
    }

    public void DoubleUpMoney()
    {
        AddMoney(moneyInRound);
    }

    public int GetMoneyInRound()
    {
        return moneyInRound;
    }

    public int GetAllMoney()
    {
        return allMoney;
    }

    public void ZeroMoney()
    {
        moneyInRound = 0;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("allMoney", allMoney);
        PlayerPrefs.Save();
    }
}
