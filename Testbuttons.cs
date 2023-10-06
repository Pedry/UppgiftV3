using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testbuttons : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;

    public void PicupItem(int id)
    {
        inventoryManager.AddItem(itemsToPickup[id]);
    }
}
