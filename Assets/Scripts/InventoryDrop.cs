using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InventoryManager))]
public class InventoryDrop : MonoBehaviour
{
    private InventoryManager inventoryManager;
    public InventoryUI InventoryUI;
    
    public GameObject ItemObjectPrefab;

    private void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
        
        InventoryUI.SlotClicked += InventoryUIOnSlotClicked;
    }

    private void InventoryUIOnSlotClicked(SlotUI slotUI, int index)
    {
        var item = inventoryManager.RemoveItem(index);
        
        if(item == null) return;

        DropItem(item);
   
    }
    
    private void DropItem(Item item)
    {
        Vector3 spawnLocation = transform.position;

        Vector3 spawnOffset = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;
        
        var newObject = Instantiate<GameObject>(ItemObjectPrefab, spawnLocation, Quaternion.identity, null);
        var boxCollider2d = newObject.GetComponent<BoxCollider2D>();

        var rb2d = newObject.GetComponent<Rigidbody2D>();
        
        StartCoroutine(FreesehBoxCollider(boxCollider2d, rb2d));
        
        rb2d.AddForce(spawnOffset, ForceMode2D.Impulse);
        
    }

    private IEnumerator FreesehBoxCollider(BoxCollider2D boxCollider2D, Rigidbody2D rigidbody2D)
    {
        boxCollider2D.enabled = false;
        yield return new WaitForSeconds(1f);
        boxCollider2D.enabled = true;
        yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
        rigidbody2D.velocity = Vector2.zero;
    }
}