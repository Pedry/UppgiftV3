using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [Header("UI")]
    public Image image;
    public Text countText;

    [HideInInspector] public Item item;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;

    

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite  = newItem.image;
        RefreshCount();
    }
   

    // stack count text
    public void RefreshCount() { 
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    // Drag and drop features
    // B�rjan p� Drag&Drop
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    // mitten p� Drag&Drop (uppdaterar positionen p� bilden/Object j�mntemot vars musen �r)
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }


    // Slutet p� Drag&Drop (kollar s� du sl�ppt knappen)
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
