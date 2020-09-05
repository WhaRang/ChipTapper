using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager manager;
    bool isEnded;

    private void Awake()
    {
        if (manager == null)
            manager = this.gameObject.GetComponent<EndGameManager>();
    }

    private void Start()
    {
        isEnded = false;
    }

    public void EndGame()
    {
        isEnded = true;
    }

    public bool IsEnded()
    {
        return isEnded;
    }
}
