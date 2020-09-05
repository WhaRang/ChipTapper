using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public HealthBar bar;
    int currPercent = 100;
    public Text percentText;

    public float maxHealth = 200.0f;
    public float health;

    private void Start()
    {
        health = maxHealth;
        currPercent = ((int)(health / maxHealth * 100));
        bar.setMaxValue(maxHealth);
        percentText.text = currPercent.ToString() + "%";
    }

    public int GetCurrPercent()
    {
        return currPercent;
    }

    public void hit(float hit)
    {
        if (health - hit < 0)
        {
            health = 0;
        }
        else
        {
            health -= hit;
        }

        currPercent = ((int)(health / maxHealth * 100));
        percentText.text = currPercent.ToString() + "%";
        bar.SetHealth(health);
    }

    public void heal(float heal)
    {
        if (health + heal > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += heal;
        }

        currPercent = ((int)(health / maxHealth * 100));
        percentText.text = currPercent.ToString() + "%";
        bar.SetHealth(health);
    }
}
