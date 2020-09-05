using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeartButtonBehaviour : MonoBehaviour, IDragHandler, IEndDragHandler
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
    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;
        HorizontalSwiper.swiper.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        HorizontalSwiper.swiper.OnEndDrag(eventData);
    }
}
