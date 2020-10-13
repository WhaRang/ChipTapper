using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorBrick : MonoBehaviour
{
    public GameObject brickFrame;
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public Color GetBrickColor()
    {
        return image.color;
    }

    public void OnPressDown()
    {
        TransformBrickOnPosition();
    }

    public void TransformBrickOnPosition()
    {
        brickFrame.gameObject.transform.position = this.gameObject.transform.position;
    }
}
