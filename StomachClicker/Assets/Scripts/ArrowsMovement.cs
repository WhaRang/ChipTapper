using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsMovement : MonoBehaviour
{
    float pause = 1f;
    float counter = 1f;
    float jumpTime = 0.8f;

    float jump = 30.0f;

    private void Update()
    {
        if (counter >= pause)
        {
            counter = 0.0f;
            TextAnimator.animator.HalfJump(gameObject, jump, jumpTime);
        }
        counter += Time.deltaTime;
    }
}
