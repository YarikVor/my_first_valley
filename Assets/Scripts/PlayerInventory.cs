using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryUI InventoryUI;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            InventoryUI.gameObject.SetActive(!InventoryUI.gameObject.activeSelf);
    }
}