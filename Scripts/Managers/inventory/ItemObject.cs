using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    public void OnHandlePickupItem()
    {
        InvetorySystem.current.Add(referenceItem);
        Destroy(gameObject);
    }
}
