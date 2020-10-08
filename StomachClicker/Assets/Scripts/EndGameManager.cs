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
    public Animator adMenuAnimator;
    public GameObject AdMenu;

    int gamePlayedFree;
    int maxGameCanBePlayedFree = 1;


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
    }

    void HandleEndForAddShowning()
    {
        gamePlayedFree++;
        if (gamePlayedFree >= maxGameCanBePlayedFree)
        {
            gamePlayedFree = 0;
            StartCoroutine(AdMenuCoroutine());
        }
        else
        {
            StartCoroutine(FadeCanvasCoroutine());
            StartCoroutine(EndGameCoroutine());
        }
        NormalEnding();
    }

    void NormalEnding()
    {
        Timer.timer.SetStopped(true);
        clickDumper.gameObject.SetActive(true);
        clickDumper.EndGame();
        BgStarter.StopAll();
        StartCoroutine(BlinkerCoroutine());
    }

    IEnumerator AdMenuCoroutine()
    {
        yield return new WaitForSeconds(pause);
        AdMenu.SetActive(true);
        adMenuAnimator.SetTrigger("In");
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

    public IEnumerator EndGameCoroutine()
    {
        yield return new WaitForSeconds(pause);
        LoadMainMenu();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene((int)BuildIndexes.INDEXES.MAIN_MENU);
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
