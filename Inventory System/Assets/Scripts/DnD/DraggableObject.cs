using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class DraggableObject : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        OnDragUpdate(eventData);
    }

    public abstract void OnDragUpdate(PointerEventData eventData);
}
