using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public static GameStarter starter;
    public bool isStarted;

    float pause = 1.7f;
    bool isHandled;

    void Awake()
    {
        if (starter == null)
            starter = this.gameObject.GetComponent<GameStarter>();
    }

    void Update()
    {
        if (isStarted && !isHandled)
        {
            isHandled = true;
            HandleStart();
        }
    }

    void HandleStart()
    {
        StartCoroutine(HandleCoroutine());
    }

    IEnumerator HandleCoroutine()
    {
        yield return new WaitForSeconds(pause);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
