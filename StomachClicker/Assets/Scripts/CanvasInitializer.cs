using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInitializer : MonoBehaviour
{
    public static Canvas canvas;

    private void Awake()
    {
        if (canvas == null)
            canvas = this.gameObject.GetComponent<Canvas>();
    }
}
