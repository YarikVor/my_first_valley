using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public const int SIZE_INVENTORY = 8;

    public static Dictionary<ItemType, int> itemMaxAmount = new Dictionary<ItemType, int>()
    {
        { ItemType.Apple, 2 },
        { ItemType.Bone, 1 }
    };

    public static InventoryManager Instance { get; private set; } = null;

    [SerializeField] private List<Item> items;

    public IReadOnlyList<Item> Items => items;

    public int InventorySize => items.Count;

    

    private void Awake()
    {
        Instance ??= this;
        Debug.Assert(Instance != null);

        items = new List<Item>(SIZE_INVENTORY);

        if (Instance != this)
        {
            Destroy(this.gameObject);
            Debug.Log("InventoryManager already exists, destroying object!");
        }
        else
        {
            InitItems();
            //DontDestroyOnLoad(this.gameObject);
        }
    }

    private void InitItems()
    {
        for (int i = 0; i < items.Capacity; i++)
        {
            items.Add(new Item());
        }
    }


    /// <returns>true, if added is success, else false, if inventory is full</returns>
    public bool AddItem(Item item)
    {
        Debug.Assert(item != null, "item == null");

        int maxAmount = itemMaxAmount[item.itemType];

        var enumerable = items
            .Where(e => e.itemType == item.itemType && e.amount < maxAmount)
            .Concat(
                items
                    .Where(e => !e.IsSet)
                    .ForEachYield(e =>
                    {
                        e.itemType = item.itemType;
                        e.sprite = item.sprite;
                    })
            );

        foreach (var to in enumerable)
        {
            to.amount += item.amount;

            if (to.amount > maxAmount)
            {
                item.amount = to.amount - maxAmount;
                to.amount = maxAmount;
            }
            else
            {
                return true;
            }
        }

        return false;
    }


    public Item RemoveItem(int index)
    {
        if (0 <= items.Count && items.Count <= index)
            return null;

        var item = items[index];

        if (item.itemType == ItemType.None)
            return null;

        var itemResult = new Item(item.itemType, item.amount, item.sprite);
        
        item.itemType = ItemType.None;
        
        return itemResult;
    }
}