using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DraggableUIObject : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDragCaller(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragCaller(eventData);
    }

    public abstract void OnDragCaller(PointerEventData eventData);
    public abstract void OnBeginDragCaller(PointerEventData eventData);
}
