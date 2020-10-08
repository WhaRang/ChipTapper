using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdFreeButton : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("Thanks for purachasing ad-free version of this game");
        SceneManager.LoadScene((int)BuildIndexes.INDEXES.MAIN_MENU);
    }
}
