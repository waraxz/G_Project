using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> startingItems;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;

    public event Action<ItemSlot> onPointerEnterEvent;
    public event Action<ItemSlot> onPointerExitEvent;
    public event Action<ItemSlot> onLeftClickEvent;
    public event Action<ItemSlot> onBeginDragEvent;
    public event Action<ItemSlot> onEndDragEvent;
    public event Action<ItemSlot> onDragEvent;
    public event Action<ItemSlot> onDropEvent;

    private void Start()
    {
        for(int i = 0;i < itemSlots.Length; i++)
        {
            itemSlots[i].onPointerEnterEvent += onPointerEnterEvent;
            itemSlots[i].onPointerExitEvent += onPointerExitEvent;
            itemSlots[i].onLeftClickEvent += onLeftClickEvent;
            itemSlots[i].onBeginDragEvent += onBeginDragEvent;
            itemSlots[i].onEndDragEvent += onEndDragEvent;
            itemSlots[i].onDragEvent += onDragEvent;
            itemSlots[i].onDropEvent += onDropEvent;

        }
        SetStartingItems();
    }

    private void OnValidate()
    {
        if(itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }
        SetStartingItems();
    }

    private void SetStartingItems()
    {
        int i = 0;
        for(; i < startingItems.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].item  = startingItems[i];
        }
        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].item = null;
        }
   
    }
    public bool AddItem(Item item)
    {
       for(int i = 0; i< itemSlots.Length; i++)
        {
            if(itemSlots[i].item == null)
            {
                itemSlots[i].item = item;
                return true;
            }
        }
        return false;
    }
    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == item)
            {
                itemSlots[i].item = null;
                return true;
            }
        }
        return false;
    }
    public bool IsFull()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == null)
            {
                
                return false;
            }
        }
        return true;
    }







}
