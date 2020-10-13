using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CameraColorSetter : MonoBehaviour
{

    public Camera mainCamera;
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnPressDown()
    {
        mainCamera.backgroundColor = image.color;
        UiSettings.settings.SetCameraColor(image.color);
    }
}
