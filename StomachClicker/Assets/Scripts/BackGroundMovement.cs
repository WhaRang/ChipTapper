using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    float deltaHeight = 2160.0f;

    float speed = 50.0f;
    Vector2 direction = new Vector2(0.0f, 1.0f);

    private void Update()
    {
        if (!GameStarter.starter.isStarted)
        {
            moveObject();
            if (this.gameObject.transform.position.y >= deltaHeight)
            {
                this.gameObject.transform.position = new Vector3(0.0f, -deltaHeight, 0.0f);
            }
        }
    }

    void moveObject()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
