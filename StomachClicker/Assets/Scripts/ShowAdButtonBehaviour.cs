using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAdButtonBehaviour : MonoBehaviour
{
    public void OnClick()
    {
        AdManager.manager.PlayRewardedVidoeAd();
        Debug.Log("we are doubling the money!");
    }
}
