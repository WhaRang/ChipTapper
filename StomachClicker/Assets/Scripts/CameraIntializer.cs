using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraIntializer : MonoBehaviour
{
    Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        mainCamera.backgroundColor = UiSettings.settings.GetCameraColor();
    }
}
