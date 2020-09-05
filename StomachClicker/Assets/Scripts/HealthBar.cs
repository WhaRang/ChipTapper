using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar bar;
    public Slider slider;
    public Image fill;

    private void Awake()
    {
        if (bar == null)
            bar = this.gameObject.GetComponent<HealthBar>();
    }

    public void setMaxValue(float maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
