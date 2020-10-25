using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewRecordBehaviour : MonoBehaviour
{
    public Text textField;
    float counter = 1f;
    public float colorSwapTime = 0.8f;

    private void Start()
    {
        counter = colorSwapTime;
    }

    private void Update()
    {
        if (counter >= colorSwapTime)
        {
            counter = 0.0f;
            TextAnimator.animator.TextColorSwap(textField, Color.black, colorSwapTime);
        }
        counter += Time.deltaTime;
    }
}
