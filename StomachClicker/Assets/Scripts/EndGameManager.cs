using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager manager;
    bool isEnded;
    float pause = 1.5f;
    float blinkerPause = 0.5f;

    public DumperBehaviour clickDumper;
    public BackGroundStarter BgStarter;
    public Animator EndGameMenuAnimator;
    public GameObject EndGameMenu;


    GameObject blinker;

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
        StartCoroutine(EndGameMenuCoroutine());
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

    IEnumerator EndGameMenuCoroutine()
    {
        yield return new WaitForSeconds(pause);
        EndGameMenu.SetActive(true);
        EndGameMenuAnimator.SetTrigger("In");
    }

    IEnumerator BlinkerCoroutine()
    {
        yield return new WaitForSeconds(blinkerPause);
        if (blinker != null)
        {
            blinker.SetActive(true);
        }
    }

    public bool IsEnded()
    {
        return isEnded;
    }

    public void SetBlinker(GameObject newBlinker)
    {
        blinker = newBlinker;
    }
}
