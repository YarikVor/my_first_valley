using System;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item item;
    
    public Rigidbody2D rb2d;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        InventoryManager inventory = other.GetComponent<InventoryManager>();

        if (inventory && inventory.AddItem(item))
        {
            Destroy(gameObject);
        }
           

    }
}