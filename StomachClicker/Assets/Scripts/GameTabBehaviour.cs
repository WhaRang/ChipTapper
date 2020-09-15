using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTabBehaviour : MonoBehaviour
{
    public bool canMove;

    float speed = 250.0f;
    float deltaSpeed = 100.0f;
    float maxSpeed = 3000.0f;
    Vector2 direction = new Vector2(0.0f, 1.0f);

    float maxHight = 5000.0f;

    void Update()
    {
        if (GameStarter.starter.isStarted)
        {
            canMove = true;
        }

        if (canMove)
        {
            moveObject();
            if (speed < maxSpeed)
            {
                speed += deltaSpeed;
            }
        }
    }

    void moveObject()
    {
        if (this.gameObject.transform.position.y < maxHight)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
