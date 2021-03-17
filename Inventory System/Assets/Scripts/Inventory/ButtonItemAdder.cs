using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;
using UnityEngine.EventSystems;

public class ButtonItemAdder : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ScriptableItem _itemToAdd;
    [SerializeField] private int _amount;
    [SerializeField] private Inventory _inventoryTarget;

    public void AddItem(){
        Item newItem = new Item();

        newItem.Name = _itemToAdd.Name;
        newItem.Description = _itemToAdd.Description;
        newItem.ItemType = _itemToAdd.ItemType;
        newItem.Amount = _amount;
        newItem.IsStackable = _itemToAdd.IsStackable;

        _inventoryTarget.AddItem(newItem);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AddItem();
    }
}
