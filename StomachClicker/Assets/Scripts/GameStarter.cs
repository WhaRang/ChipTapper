using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public static GameStarter starter;
    public bool isStarted;

    void Awake()
    {
        if (starter == null)
            starter = this.gameObject.GetComponent<GameStarter>();
    }
}
