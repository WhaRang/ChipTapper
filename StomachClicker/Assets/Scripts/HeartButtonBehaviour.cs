using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeartButtonBehaviour : MonoBehaviour
{
    public Health brain;
    public Health heart;
    public Health stomach;

    public float heartHeal;
    public float brainDamage;
    public float stomachDamage;

    bool isDragging = false;

    public void OnButtonDown()
    {
        if (isDragging)
        {
            isDragging = false;
            return;
        }
        heart.heal(heartHeal);
        stomach.hit(stomachDamage);
        brain.hit(brainDamage);
    }
}
