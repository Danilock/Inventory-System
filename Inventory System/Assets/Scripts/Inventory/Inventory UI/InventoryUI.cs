using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Inventory _inventoryDataSource;

        [Header("Slot Handler")]
        [SerializeField] private UISlot _slotPrefab;
        [SerializeField] private GridLayoutGroup _layoutGroup; 

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
                                        slot.CurrentSlotData.CurrentItem.ItemType ==
                                        newSlotData.CurrentItem.ItemType
                                        );
            
            if(slot != null)
                slot.SetData(newSlotData.CurrentItem);
        }
    }
}