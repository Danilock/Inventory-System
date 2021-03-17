using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace InventorySystem{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<Item> _items;
        public List<Item> Items{
            get => _items;
            private set => _items = value;
        }
        [SerializeField] private int _maxSize = 10;

        private void Awake() {
            _items.Capacity = _maxSize;
        }

        public void AddItem(Item newItem){
            if(_items.Count >= _maxSize){
                Debug.LogWarning("Exceded inventory size!!!");
                return;
            }

            if(newItem.IsStackable){
                bool isActuallyOnInventory = false;

                foreach(Item actualItem in _items){
                    if(actualItem.ItemType == newItem.ItemType){
                        actualItem.Amount += newItem.Amount;
                        isActuallyOnInventory = true;
                    }
                }

                if(!isActuallyOnInventory){
                    _items.Add(newItem);
                }
            }
            else
                _items.Add(newItem);
        }
    }
}