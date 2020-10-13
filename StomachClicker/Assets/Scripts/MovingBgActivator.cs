using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBgActivator : MonoBehaviour
{
    bool isActive;
    public CanvasGroup MovingBG;

    public void OnPressDown()
    {
        isActive = !isActive;
        HandleAlpha();
    }

    public void SetIsActive(bool newValue)
    {
        isActive = newValue;
        HandleAlpha();
    }
         
    void HandleAlpha()
    {
        if (isActive)
        {
            MovingBG.alpha = 1.0f;
            UiSettings.settings.SetMovingBgAlpha(1.0f);
        }
        else
        {
            MovingBG.alpha = 0.0f;
            UiSettings.settings.SetMovingBgAlpha(0.0f);
        }
    }
}
