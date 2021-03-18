using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace InventorySystem{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Inventory _inventoryDataSource;

        [Header("Slot Handler")]
        [SerializeField] private UISlot _slotPrefab;
        [SerializeField] private GridLayoutGroup _layoutGroup; 
        [SerializeField] private Button _canvasTriggerButton;

        [SerializeField] private GameObject _inventoryContainer;
        private bool _isVisible = false;

        private List<UISlot> _slots = new List<UISlot>();

        private void Start() {
            InitializeChildContent();
        }

        private void OnEnable() {
            _inventoryDataSource.OnAddItem.AddListener(AddNewUISlot);
            _inventoryDataSource.OnModifyItem.AddListener(ModifyExistingSlot);
        }

        private void OnDisable() {
            _inventoryDataSource.OnAddItem.RemoveListener(AddNewUISlot);
            _inventoryDataSource.OnModifyItem.RemoveListener(ModifyExistingSlot);
        }

        private void InitializeChildContent(){
            for(int i = 0; i < _inventoryDataSource.Slots.Capacity; i++){
                AddUISlot();
            }
        }

        private void AddUISlot(){
            
            UISlot currentSlot = Instantiate(_slotPrefab);

            currentSlot.transform.SetParent(_layoutGroup.transform);
            currentSlot.transform.localScale = new Vector3(1f, 1f, 1f);

            _slots.Add(currentSlot);
        }
        
        private void AddNewUISlot(Item newItemData){
            UISlot emptySlot = _slots.Find(slot => slot.CurrentSlotData.CurrentItem == null);

            emptySlot.SetData(newItemData);
        }

        private void ModifyExistingSlot(ItemSlot newSlotData){
            UISlot slot = _slots.Find(slot => 
                                        slot.CurrentSlotData.CurrentItem.Name ==
                                        newSlotData.CurrentItem.Name
                                        );
            
            if(slot != null)
                slot.SetData(newSlotData.CurrentItem);
        }

        //In case there is a button/function that can Open and Close the inventory
        public void TriggerInventoryView(){
            if(!_isVisible)
                ShowInventory();
            else
                HideInventory();
        }

        public void ShowInventory(){
            Sequence showSequence = DOTween.Sequence();

            showSequence.Append(_inventoryContainer.transform.DOScale(1f, .3f));
            showSequence.Append(_canvasTriggerButton.transform.DOScale(0f, .5f));
            _isVisible = true;
        }

        public void HideInventory(){
            Sequence showSequence = DOTween.Sequence();

            showSequence.Append(_inventoryContainer.transform.DOScale(0f, .3f));
            showSequence.Append(_canvasTriggerButton.transform.DOScale(1, .5f));
            _isVisible = false;
        }
    }
}