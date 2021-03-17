using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

namespace InventorySystem{
    public class DraggableItemSlot : DraggableObject, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private Image _itemIcon;
        [SerializeField] private TMP_Text _itemNameText;
        [SerializeField] private TMP_Text _itemAmountText;
        private Vector2 _initialPosition;
        public RectTransform _draggableRect;
        private Image _draggableFontImage;
        private CanvasGroup _group;

        private void Start() {
            _draggableFontImage = GetComponent<Image>();
            _draggableRect = GetComponent<RectTransform>();
            _group = GetComponent<CanvasGroup>();
        }

        public override void OnDragUpdate(PointerEventData eventData)
        {
            
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            SetChildrenMaskeableState(true);
            _group.blocksRaycasts = true;

            DraggableItemSlot itemSlot = eventData.pointerEnter.GetComponent<DraggableItemSlot>();

            SwitchItemSlot(itemSlot);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            SetChildrenMaskeableState(false);
            _group.blocksRaycasts = false;

            _initialPosition = _draggableRect.anchoredPosition;
        }

        private void SetChildrenMaskeableState(bool value){
            _itemIcon.maskable = value;
            _itemAmountText.maskable = value;
            _itemNameText.maskable = value;
            _draggableFontImage.maskable = value;
        }

        private void SwitchItemSlot(DraggableItemSlot itemSlot){
            this._draggableRect.anchoredPosition = itemSlot._draggableRect.anchoredPosition;
            
            itemSlot._draggableRect.anchoredPosition = this._initialPosition;
        }
    }
}