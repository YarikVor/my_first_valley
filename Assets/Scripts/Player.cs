
using System.Collections;
using UnityEngine;

public class Player: MonoBehaviour
{
    public InventoryManager inventoryManager;
    
    void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }
    
 
}
