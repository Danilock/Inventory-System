using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GenericDraggableObject : MonoBehaviour, IDragHandler
{
    [SerializeField] private Canvas _canvas;
    private RectTransform _rectTransform;
    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
}
