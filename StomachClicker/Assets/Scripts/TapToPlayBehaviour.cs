using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToPlayBehaviour : MonoBehaviour
{
    public Text textField;

    float pause = 1.8f;
    float counter = 1.8f;
    float jumpTime = 1.35f;

    float jump = 50.0f;
    public bool shouldMove;

    void Update()
    {
        if (!shouldMove)
        {
            if (counter >= pause)
            {
                counter = 0.0f;
                TextAnimator.animator.HalfJump(textField, jump, jumpTime);
            }
            counter += Time.deltaTime;
        }
    }
}
