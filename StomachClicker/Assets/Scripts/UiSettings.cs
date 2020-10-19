using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISettings : MonoBehaviour
{
    public static UISettings settings;

    public Color defaultCameraColor;
    Color cameraColor;
    float movingBgAlpha;

    private void Awake()
    {
        if (settings == null)
            settings = this.gameObject.GetComponent<UISettings>();

        DontDestroyOnLoad(gameObject);

        movingBgAlpha = PlayerPrefs.GetFloat("movingBgAlpha", movingBgAlpha);

        cameraColor.r = PlayerPrefs.GetFloat("cameraColorR", defaultCameraColor.r);
        cameraColor.g = PlayerPrefs.GetFloat("cameraColorG", defaultCameraColor.g);
        cameraColor.b = PlayerPrefs.GetFloat("cameraColorB", defaultCameraColor.b);
        cameraColor.a = PlayerPrefs.GetFloat("cameraColorA", defaultCameraColor.a);
    }

    public void SetMovingBgAlpha(float alpha)
    {
        movingBgAlpha = alpha;
    }

    public float GetMovingBgAlpha()
    {
        return movingBgAlpha;
    }

    public void SetCameraColor(Color newColor)
    {
        cameraColor = newColor;
    }

    public Color GetCameraColor()
    {
        return cameraColor;
    }

    private void OnDestroy()
    {
        SaveCameraColor();
        SaveMovingBgAlpha();
        PlayerPrefs.Save();
    }

    void SaveMovingBgAlpha()
    {
        PlayerPrefs.SetFloat("movingBgAlpha", movingBgAlpha);
    }

    void SaveCameraColor()
    {
        PlayerPrefs.SetFloat("cameraColorR", cameraColor.r);
        PlayerPrefs.SetFloat("cameraColorG", cameraColor.g);
        PlayerPrefs.SetFloat("cameraColorB", cameraColor.b);
        PlayerPrefs.SetFloat("cameraColorA", cameraColor.a);
    }
}
