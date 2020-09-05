using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StomachButtonBehaviour : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Health brain;
    public Health heart;
    public Health stomach;

    public float stomachHeal;
    public float brainDamage;
    public float heartDamage;

    bool isDragging = false;

    public void OnButtonDown()
    {
        if (isDragging)
        {
            isDragging = false;
            return;
        }
        stomach.heal(stomachHeal);
        brain.hit(brainDamage);
        heart.hit(heartDamage);
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
