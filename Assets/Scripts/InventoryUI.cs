using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject InventoryUIObject;

    public InventoryManager inventoryManager;

    public GameObject SlotsUI;

    private List<SlotUI> slotsUIList;
    
    public event Action<SlotUI, int> SlotClicked;
    

    public static void TestOnSlotClick(SlotUI slotUI, int index)
    {
        Debug.Log($"Slot {index} clicked");
    }
    
    private void Start()
    {
        gameObject.SetActive(false);
        
        Debug.Log("InventoryUI Start");
        SetupSlotUIList();
        SlotClicked += TestOnSlotClick;
        
    }

    void SetupSlotUIList()
    {
        slotsUIList = new List<SlotUI>(SlotsUI.GetComponentsInChildren<SlotUI>());
        
        Debug.Assert(inventoryManager);
        
        if(inventoryManager.InventorySize != slotsUIList.Count)
            throw new Exception($"Inventory size and slots count are not equal ({inventoryManager.InventorySize} != {slotsUIList.Count})");

        OnVisibleInventory();
        
        Debug.Log("SetupSlotUIList");
        
        Debug.Log(nameof(SetupSlotUIList));
        
        slotsUIList.ForEach((slotUI, index) =>
        {
            Debug.Assert(slotUI.button);           
            slotUI.button.onClick.AddListener(() =>
            {
                SlotClicked?.Invoke(slotUI, index);
            });
        });
    }
    
    void OnEnable()
    {
        if (InventoryUIObject.activeSelf)
        {
            Debug.Log("Inventory is visible");
            OnVisibleInventory();
        }
    }

    private void OnDisable()
    {
        
    }


    void OnVisibleInventory()
    {
        inventoryManager.Items.ForEach((item, index) =>
        {
            slotsUIList[index].SetItem(item);
        });
    }

    
    

}