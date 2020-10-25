using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclingJump : MonoBehaviour
{
    float pause = 1f;
    float counter = 1f;
    public float jumpTime = 0.8f;

    public float jump = 30.0f;

    private void Start()
    {
        pause = jumpTime + jumpTime / 4;
        counter = pause;
    }

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
