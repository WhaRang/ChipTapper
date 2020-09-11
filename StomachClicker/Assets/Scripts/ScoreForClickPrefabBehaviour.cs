using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreForClickPrefabBehaviour : MonoBehaviour
{
    const float LIFE_TIME = 0.3f;
    float counter = 0.0f;
    public Text textField;

    float speed = 500.0f;
    Vector2 direction = new Vector2(0.0f, 1.0f);

    public void SetText(string _text)
    {
        textField.text = _text;
    }

    private void Update()
    {
        moveObject();
        counter += Time.deltaTime;
        if (counter >= LIFE_TIME)
        {
            Destroy(gameObject);
        }
    }

    void moveObject()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
