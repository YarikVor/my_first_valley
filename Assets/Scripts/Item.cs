using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public class Item
{
    public ItemType itemType;
    public int amount;
    public Sprite sprite;

    public bool IsEmpty => amount == 0;
    
    public bool IsSet => itemType != ItemType.None;

    public bool IsInitialized => IsSet && amount > 0;
    
    
    public Item(ItemType itemType, int amount, Sprite sprite)
    {
        this.itemType = itemType;
        this.amount = amount;
        this.sprite = sprite;
    }
    
    public Item(ItemType itemType, int amount)
    {
        this.itemType = itemType;
        this.amount = amount;
    }

    public Item(ItemType itemType) : this(itemType, 0)
    {
        
    }
    
    public Item() : this(ItemType.None)
    {
        
    }
    
    public void SetEmpty()
    {
        itemType = ItemType.None;
        amount = 0;
        sprite = null;
    }

}