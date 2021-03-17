using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace InventorySystem{
    public class UISlot : MonoBehaviour
    {
        [SerializeField] private Image _itemIcon;
        [SerializeField] private TMP_Text _itemText;
        [SerializeField] private TMP_Text _itemAmount;
        private ItemSlot _currentSlotData;
        public ItemSlot CurrentSlotData{
            get => _currentSlotData;
            set{
                _currentSlotData = value;
            }
        }

        private void Start() {
            CurrentSlotData = new ItemSlot();
        }

        public void SetData(Item newItem){
            CurrentSlotData.CurrentItem = newItem;

            _itemAmount.text = newItem.Amount.ToString();
            _itemIcon.sprite = newItem.ItemPortrait;
            _itemText.text = newItem.Name;
        }
    }
}