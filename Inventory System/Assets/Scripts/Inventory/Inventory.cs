using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

namespace InventorySystem{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<ItemSlot> _slots;
        public List<ItemSlot> Slots{
            get => _slots;
            private set => _slots = value;
        }
        [SerializeField, Range(1, 18)] private int _maxSize = 10;

        public UnityEvent<Item> OnAddItem;
        public UnityEvent<ItemSlot> OnModifyItem;

        private void Awake() {
            Slots.Capacity = _maxSize;
        }

        public void AddItem(Item newItem){
            if(newItem.IsStackable){
                bool isActuallyOnInventory = false;

                foreach(ItemSlot actualSlot in _slots){
                    if(actualSlot.CurrentItem.ItemType == newItem.ItemType){
                        actualSlot.CurrentItem.Amount += newItem.Amount;
                        OnModifyItem.Invoke(actualSlot);
                        isActuallyOnInventory = true;
                    }
                }

                if(!isActuallyOnInventory){
                    CreateSlot(newItem);
                }
            }
            else
                CreateSlot(newItem);
        }

        public void CreateSlot(Item itemOnSlot){
            if(_slots.Count >= _maxSize){
                Debug.LogWarning("Exceded inventory size!!!");
                return;
            }

            ItemSlot slot = new ItemSlot();

            if(itemOnSlot != null){
                slot.CurrentItem = itemOnSlot;
                OnAddItem.Invoke(itemOnSlot);
            }

            Slots.Add(slot);
        }
    }
}