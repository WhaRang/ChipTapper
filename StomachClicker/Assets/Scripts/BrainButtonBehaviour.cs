using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrainButtonBehaviour : MonoBehaviour
{
    public Health brain;
    public Health heart;
    public Health stomach;

    public float brainHeal;
    public float stomachDamage;
    public float heartDamage;

    bool isDragging = false;

    public void OnButtonDown()
    {
        if (isDragging)
        {
            return;
        }
        brain.heal(brainHeal);
        stomach.hit(stomachDamage);
        heart.hit(heartDamage);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
    }
}
