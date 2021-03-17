using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem{
    public class ItemDropArea : DropArea
    {
        [SerializeField] private Transform _content;
        public override void OnDropCaller(PointerEventData eventData)
        {
            
        }
    }
}