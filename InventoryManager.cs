using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxStackedItems = 100;
    public InventorySlot[] InventorySlots;
    public GameObject inventoryItemPrefab;
     
    int selectedSlot = -1;
    
    
    
    // ser till att en slot är selected för att indikera vilken slot som är "aktiv"
    public void Start()
    {
        ChangedSelectedSlot(0);
    }

    // Update checkar vilken slot i tool'baren som är aktiv. (mellan 1-6)
    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 7 )
            {
                ChangedSelectedSlot  (number - 1);
            }
        }
    }
    
    

    // denna ändrar färg på selected slot
    void ChangedSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
        InventorySlots[selectedSlot].Deselected();


        }
        
        InventorySlots[newValue].selected();
        selectedSlot = newValue;
    }

    
    //här adderar/skapar jag nya items
    public bool AddItem(Item item)
    {
        // check if any slot has same item count
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            InventorySlot slot = InventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null &&
                itemInSlot.item == item &&
                itemInSlot.count < maxStackedItems &&
                itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        
        
        //Here i look for empty slots in inventory
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            InventorySlot slot = InventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                    return true;
            }
        }
        return false;
    }

    
    // denna ser till så items är olika och nya
    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }


}


