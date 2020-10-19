using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBgInitializer : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup.alpha = UISettings.settings.GetMovingBgAlpha();
    }
}
