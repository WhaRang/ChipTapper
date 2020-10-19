using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaletteInitializer : MonoBehaviour
{
    public ColorBrick[] bricks;

    private void Start()
    {
        foreach (ColorBrick brick in bricks)
        {
            if (brick.GetBrickColor() == UISettings.settings.GetCameraColor())
            {
                brick.TransformBrickOnPosition();
                return;
            }
        }
    }
}
