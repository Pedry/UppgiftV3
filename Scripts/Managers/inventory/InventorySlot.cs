using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{

 public Image image;
 public Color selectedColor, notSelectedColor;


    public void Awake()
    {
        Deselected();
    }

    public void selected()
    {
        image.color = selectedColor;
    }

    public void Deselected()
    {
        image.color = notSelectedColor;

    }
    

    public void OnDrop(PointerEventData eventData){
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem inventoryitem = dropped.GetComponent<InventoryItem>();
            inventoryitem.parentAfterDrag = transform;
        }
   
   
    
    
    
    }

}
    
    
    


    

