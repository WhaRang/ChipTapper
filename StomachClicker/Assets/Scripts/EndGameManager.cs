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

    public DumperBehaviour clickDumper;
    public BackGroundStarter BGstarter;
    public Animator canvasAnimator;

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
        StartCoroutine(EndGameCoroutine());
        clickDumper.gameObject.SetActive(true);
        clickDumper.EndGame();
        BGstarter.StopAll();
        StartCoroutine(FadeCanvasCoroutine());
    }

    IEnumerator FadeCanvasCoroutine()
    {
        yield return new WaitForSeconds(canvasFadePause);
        canvasAnimator.SetTrigger("Out");
    }

    IEnumerator EndGameCoroutine()
    {
        yield return new WaitForSeconds(pause);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public bool IsEnded()
    {
        return isEnded;
    }
}
