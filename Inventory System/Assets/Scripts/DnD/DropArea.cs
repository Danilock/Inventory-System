using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DropArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        OnDropCaller(eventData);
    }

    public abstract void OnDropCaller(PointerEventData eventData);
}
