using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using DG.Tweening;

public class Slot : MonoBehaviour,IDragHandler,IEndDragHandler,IDropHandler,IBeginDragHandler
{
    public Item item;
    public Image itemIcon;
    GameObject test;
     Inventory inven;
    Vector3 returnPosition;

    public GameObject UICanvas;
    Transform Parent;
    void Start()
    {
         test = transform.GetChild(1).gameObject;

        inven = GameObject.Find("Player").GetComponent<Inventory>();
        returnPosition =test.transform.localPosition;

        Parent = transform.parent;
    }
    public void UpdateSlotUI()
    {
       // Debug.Log("인벤토리에 이미지 넣기");
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }

    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null && inven.items.Count != 0)
        {
            transform.SetParent(UICanvas.transform);
        }
        
    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (item != null && inven.items.Count != 0)
        {
            test.transform.position = eventData.position;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (item != null && inven.items.Count != 0)
        {
            test.transform.localPosition = returnPosition;

            transform.SetParent(Parent.transform);

        }

    }

   

    public void OnDrop(PointerEventData eventData)
    {

    }

   
}
