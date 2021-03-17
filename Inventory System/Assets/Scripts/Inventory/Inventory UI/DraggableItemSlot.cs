using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventorySystem{
    [RequireComponent(typeof(UISlot))]
    public class DraggableItemSlot : DraggableUIObject, IEndDragHandler
    {
        public UISlot UISlot{ get;  private set;}
        
        
        private CanvasGroup _itemSlotGroup;
        public GameObject PlaceHolder;
        public Transform ParentToReturnTo;
        private LayoutElement _itemLayout;
        public int GetSiblingIndex{
            get{
                return this.transform.GetSiblingIndex();
            }
        }

        public int LastSiblingPosition;

        public override void OnBeginDragCaller(PointerEventData eventData)
        {
            //Removing the parent
            if(UISlot.CurrentSlotData.CurrentItem == null)
                return;

            LastSiblingPosition = this.transform.GetSiblingIndex();

            InitializePlaceHolder();

            SetUIMaskeable(false);
            
            ParentToReturnTo = this.transform.parent;

            this.transform.SetParent(this.transform.parent.parent);
            _itemSlotGroup.blocksRaycasts = false;
        }

        public override void OnDragCaller(PointerEventData eventData)
        {
            //Moving the item to mouse position
            if(UISlot.CurrentSlotData.CurrentItem != null)
                this.transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(UISlot.CurrentSlotData.CurrentItem == null)
                return;
            
            DraggableItemSlot itemSlot = eventData.pointerEnter?.GetComponent<DraggableItemSlot>();

            if(itemSlot != null)
                SwithItem(itemSlot);
            else
                ReturnToPlaceHolder();
            
        }

        private void Start() {
            UISlot = GetComponent<UISlot>();
            _itemSlotGroup = GetComponent<CanvasGroup>();
            _itemLayout = GetComponent<LayoutElement>();

            ParentToReturnTo = this.transform.parent;
        }

        private void InitializePlaceHolder(){
            PlaceHolder = new GameObject("PlaceHolder");
            PlaceHolder.transform.SetParent(this.transform.parent);

            LayoutElement layout = PlaceHolder.AddComponent<LayoutElement>();

            PlaceHolder.transform.SetSiblingIndex( this.transform.GetSiblingIndex() );
        }
    
        private void SetUIMaskeable(bool value) => UISlot.SetMaskeable(value);

        public void SwithItem(DraggableItemSlot other){
            SetPosition(other.ParentToReturnTo, other.transform
            .GetSiblingIndex());

            other.SetPosition(PlaceHolder.transform.parent, PlaceHolder.transform.GetSiblingIndex());

            Destroy(PlaceHolder);
        }

        public void ReturnToPlaceHolder(){
            _itemSlotGroup.blocksRaycasts = true;
            
            SetPosition(this.ParentToReturnTo, PlaceHolder.transform.GetSiblingIndex());

            Destroy(PlaceHolder);
        }

        public void SetPosition(Transform parentToReturnTo, int siblingIndex){
            _itemSlotGroup.blocksRaycasts = true;
         
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(siblingIndex);
        }
    }
}