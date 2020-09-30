using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public static GameLoader loader;

    private void Awake()
    {
        loader = this;        
        LoadGame();
    }

    public void LoadGame()
    {
        StartCoroutine(SceneLoadCoroutine());
    }

    IEnumerator SceneLoadCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
