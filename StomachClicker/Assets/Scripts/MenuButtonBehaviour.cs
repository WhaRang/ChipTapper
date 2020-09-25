using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonBehaviour : MonoBehaviour
{
    public GameObject dumper;
    public GameObject menu;

    public Animator dumperAnimator;

    float speed = 2400.0f;
    float menuWidth = 800.0f;
    float movedFor;
    bool canMove;
    float scaler;

    Vector3 direction = new Vector3(-1.0f, 0.0f, 0.0f);

    public void OnClick()
    {
        dumper.SetActive(true);
        dumperAnimator.SetTrigger("In");
        menu.SetActive(true);
        canMove = true;
    }

    private void Start()
    {
        scaler = CanvasInitializer.canvas.transform.localScale.x;
        menuWidth = scaler * menuWidth;
    }

    private void Update()
    {
        if (canMove)
        {
            if (movedFor < menuWidth)
            {
                menu.transform.Translate(direction * Time.deltaTime * speed);
                movedFor += Time.deltaTime * speed;
            } 
            else
            {
                float deltaX = movedFor - menuWidth;
                menu.transform.Translate(-direction * deltaX);
                canMove = false;
            }
        }
    }
}
