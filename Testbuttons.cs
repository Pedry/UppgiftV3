using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// denna class gör så man kan spawna in items för testing purposes.
public class Testbuttons : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;

    public void PicupItem(int id)
    {
        inventoryManager.AddItem(itemsToPickup[id]);
    }
}
