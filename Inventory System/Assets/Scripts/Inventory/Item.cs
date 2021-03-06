using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string Name;
    public string Description;
    public ItemTypeData ItemType;
    public bool IsStackable;
    public int Amount;
    public Sprite ItemPortrait;
}
