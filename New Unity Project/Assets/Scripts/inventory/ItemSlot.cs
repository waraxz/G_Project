using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler,  IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Image image;
    [SerializeField] Text text;

    public event Action<ItemSlot> onPointerEnterEvent;
    public event Action<ItemSlot> onPointerExitEvent;
    public event Action<ItemSlot> onLeftClickEvent;
    public event Action<ItemSlot> onBeginDragEvent;
    public event Action<ItemSlot> onEndDragEvent;
    public event Action<ItemSlot> onDragEvent;
    public event Action<ItemSlot> onDropEvent;

    private Item _item;
    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item == null)
            {
                image.color = Color.clear;
                text.color = Color.clear;
            }
            else
            {
                //โชว์รูปไอเท็ม
                image.sprite = _item.tk_icon;
                // แสดงรูป
                image.color = Color.white;
                //ชื่อไอเท็มตรงกับ text
                text.text = _item.name;
                // แสดง text
                text.color = Color.white;
            }
        }
    }


    protected virtual void OnValidate()
    {
        if (image == null)
            //ดึง image จากที่อยู่ใน childen อีกที
            image = GetComponentInChildren<Image>();
            //ดึง text จากที่อยู่ใน childen อีกที
            text = GetComponentInChildren<Text>();                  
    }

    public virtual bool CanReceiveItem(Item item)
    {
        return true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       if(eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if (onLeftClickEvent != null)
                onLeftClickEvent(this);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (onPointerEnterEvent != null)
            onPointerEnterEvent(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (onPointerExitEvent != null)
            onPointerExitEvent(this);
    }
 
    public void OnBeginDrag(PointerEventData eventData)
    {

        if (onBeginDragEvent != null)
            onBeginDragEvent(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (onEndDragEvent != null)
            onEndDragEvent(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (onDragEvent != null)
            onDragEvent(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (onDropEvent != null)
            onDropEvent(this);
    }
}
