﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchAdButton : MonoBehaviour
{
    public void OnClick()
    {
        AdManager.manager.PlayInterstitialAd();
        EndGameManager.manager.LoadMainMenu();
    }
}
