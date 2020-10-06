using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrainButtonBehaviour : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
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

    public void OnDrag(PointerEventData eventData)
    {
        HorizontalSwiper.swiper.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        HorizontalSwiper.swiper.OnEndDrag(eventData);
        isDragging = false;
    }
}
