using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Inventory _inventoryDataSource;

        private Item _items;

        [Header("Slot Handler")]
        [SerializeField] private GameObject _slotPrefab;
        [SerializeField] private GridLayoutGroup _layoutGroup; 

        private void Start() {
            InitializeChildContent();
        }

        private void InitializeChildContent(){
            for(int i = 0; i < _inventoryDataSource.Items.Capacity; i++){
                GameObject currentSlot = Instantiate(_slotPrefab);

                currentSlot.transform.SetParent(_layoutGroup.transform);
                currentSlot.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
}