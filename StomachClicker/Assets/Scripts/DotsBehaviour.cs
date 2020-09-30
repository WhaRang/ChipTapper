using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotsBehaviour : MonoBehaviour
{
    const float DELTA_PAUSE = 1.0f;

    public Text dots;
    float pause = 0.25f;

    float counter = 1.0f;

    private void Update()
    {
        if (counter >= DELTA_PAUSE)
        {
            counter = 0.0f;
            dots.text = "";
            TextAnimator.animator.TypewriteText(dots, "...", pause);
        }
        counter += Time.deltaTime;
    }
}
