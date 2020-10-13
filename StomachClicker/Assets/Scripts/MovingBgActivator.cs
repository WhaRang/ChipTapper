using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBgActivator : MonoBehaviour
{
    bool isActive = true;
    public CanvasGroup MovingBG;

    public void OnPressDown()
    {
        isActive = !isActive;
        if (isActive)
        {
            MovingBG.alpha = 1.0f;
        }
        else
        {
            MovingBG.alpha = 0.0f;
        }
    }
}
