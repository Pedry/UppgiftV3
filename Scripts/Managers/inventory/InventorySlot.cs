using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    // färg för selected slot
 public Image image;
 public Color selectedColor, notSelectedColor;

    // deselect/ neutral color vilket är standard
    public void Awake()
    {
        Deselected();
    }

    // selected color vilket går att sätta i inspectorn och händer när du väl
    public void selected()
    {
        image.color = selectedColor;
    }

    // Deselected är neutral färgen som går igång när said item inte är selected
    public void Deselected()
    {
        image.color = notSelectedColor;

    }
    
    // gör så jag kan flytta items mellan slots
    public void OnDrop(PointerEventData eventData){
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem inventoryitem = dropped.GetComponent<InventoryItem>();
            inventoryitem.parentAfterDrag = transform;
        }
   
   
    
    
    
    }

}
    
    
    


    

