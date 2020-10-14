using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSettings : MonoBehaviour
{
    public static UiSettings settings;

    public Color defaultCameraColor;
    Color cameraColor;
    float movingBgAlpha;

    private void Awake()
    {
        if (settings == null)
            settings = this.gameObject.GetComponent<UiSettings>();

        DontDestroyOnLoad(gameObject);

        movingBgAlpha = PlayerPrefs.GetFloat("movingBgAlpha", movingBgAlpha);

        float r = 0f, g = 0f, b = 0, a = 0f;
        r = PlayerPrefs.GetFloat("cameraColorR", r);
        g = PlayerPrefs.GetFloat("cameraColorG", g);
        b = PlayerPrefs.GetFloat("cameraColorB", b);
        a = PlayerPrefs.GetFloat("cameraColorA", a);

        if (r == 0f && g == 0f && b == 0f)
        {
            cameraColor = defaultCameraColor;
        }
        else
        {
            cameraColor = new Color(r, g, b, a);
        }
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
