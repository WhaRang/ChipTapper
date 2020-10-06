using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager manager;
    bool isEnded;
    float pause = 1.5f;
    float canvasFadePause = 1.1f;
    float blinkerPause = 0.5f;

    public DumperBehaviour clickDumper;
    public BackGroundStarter BgStarter;
    public Animator canvasAnimator;

    int gamePlayedFree;
    int maxGameCanBePlayedFree = 2;


    GameObject blinker;

    private void Awake()
    {
        if (manager == null)
            manager = this.gameObject.GetComponent<EndGameManager>();
    }

    private void Start()
    {
        isEnded = false;
        gamePlayedFree = PlayerPrefs.GetInt("gamePlayedFree");
    }

    public void EndGame()
    {
        isEnded = true;
        HandleEndForAddShowning();
        Timer.timer.SetStopped(true);
        StartCoroutine(EndGameCoroutine());
        clickDumper.gameObject.SetActive(true);
        clickDumper.EndGame();
        BgStarter.StopAll();
        StartCoroutine(FadeCanvasCoroutine());
        StartCoroutine(BlinkerCoroutine());
    }

    void HandleEndForAddShowning()
    {
        gamePlayedFree++;
        if (gamePlayedFree >= maxGameCanBePlayedFree)
        {
            gamePlayedFree = 0;
            AdManager.manager.PlayInterstitialAd();
        }
    }

    IEnumerator BlinkerCoroutine()
    {
        yield return new WaitForSeconds(blinkerPause);
        if (blinker != null)
        {
            blinker.SetActive(true);
        }
    }

    IEnumerator FadeCanvasCoroutine()
    {
        yield return new WaitForSeconds(canvasFadePause);
        canvasAnimator.SetTrigger("Out");
    }

    IEnumerator EndGameCoroutine()
    {
        yield return new WaitForSeconds(pause);
        LoadMainMenu();
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public bool IsEnded()
    {
        return isEnded;
    }

    public void SetBlinker(GameObject newBlinker)
    {
        blinker = newBlinker;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("gamePlayedFree", gamePlayedFree);
        PlayerPrefs.Save();
    }
}
