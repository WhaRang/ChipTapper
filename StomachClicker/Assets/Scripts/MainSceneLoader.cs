using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneLoader : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene((int)BuildIndexes.INDEXES.MAIN_MENU);
    }
}
