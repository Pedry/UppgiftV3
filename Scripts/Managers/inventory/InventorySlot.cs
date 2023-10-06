using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    // f�rg f�r selected slot
 public Image image;
 public Color selectedColor, notSelectedColor;

    // deselect/ neutral color vilket �r standard
    public void Awake()
    {
        Deselected();
    }

    // selected color vilket g�r att s�tta i inspectorn och h�nder n�r du v�l
    public void selected()
    {
        image.color = selectedColor;
    }

    // Deselected �r neutral f�rgen som g�r ig�ng n�r said item inte �r selected
    public void Deselected()
    {
        image.color = notSelectedColor;

    }
    
    // g�r s� jag kan flytta items mellan slots
    public void OnDrop(PointerEventData eventData){
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem inventoryitem = dropped.GetComponent<InventoryItem>();
            inventoryitem.parentAfterDrag = transform;
        }
   
   
    
    
    
    }

}
    
    
    


    

