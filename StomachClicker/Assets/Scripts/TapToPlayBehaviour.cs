﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToPlayBehaviour : MonoBehaviour
{
    public Text textField;

    float pause = 3.0f;
    float counter = 3.0f;
    float jumpTime = 2.0f;

    float jump = 50.0f;

    public bool isPressed;

    void Update()
    {
        if (!isPressed)
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
