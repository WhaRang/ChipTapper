using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ChooseableElement : MonoBehaviour
{
    public GameObject frame;
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
        frame.gameObject.transform.position = this.gameObject.transform.position;
    }
}
