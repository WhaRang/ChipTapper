using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaletteInitializer : MonoBehaviour
{
    public ChooseableElement[] bricks;

    private void Start()
    {
        foreach (ChooseableElement brick in bricks)
        {
            if (brick.GetBrickColor() == UISettings.settings.GetCameraColor())
            {
                brick.TransformBrickOnPosition();
                return;
            }
        }
    }
}
