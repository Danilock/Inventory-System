using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem{
    [CreateAssetMenu(fileName = "Item", menuName = "Item")]
    public class ScriptableItem : ScriptableObject
    {
        public string Name;
        [TextArea] public string Description;
        public Sprite ItemPortrait;
        public ItemTypeData ItemType;

        [Header("Stack")]
        public bool IsStackable;
    }
}

public enum ItemTypeData
{
    Sword,
    Shield,
    Healer,
    Arrow
}