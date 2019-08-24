using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image image;
    [SerializeField] Text text;
    public event Action<Item> onRightClickEvent;
    
    private Item _item;
    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item == null)
            {
                image.enabled = false;
                text.enabled = false;
            }
            else
            {
                image.sprite = _item.tk_icon;
                image.enabled = true;

                text.text = _item.name;
                text.enabled = true;
            }
        }
    }
   
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if(item !=null && onRightClickEvent != null)
            
                onRightClickEvent(item);
            
        }
    }


    protected virtual void OnValidate()
    {
        if (image == null)
            image = GetComponentInChildren<Image>();
            text = GetComponentInChildren<Text>();
       
            
    }

}
