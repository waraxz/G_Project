using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{

    [SerializeField] List<Item> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;

    public event Action<Item> onItemRightClickedEvent;

    private void Awake()
    {
        for(int i = 0;i < itemSlots.Length; i++)
        {
            itemSlots[i].onRightClickEvent += onItemRightClickedEvent;
            
        }
    }

    private void OnValidate()
    {
        if(itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }
        RefeshUI();
    }

    private void RefeshUI()
    {
        int i = 0;
        for(; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].item  = items[i];
        }
        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].item = null;
        }
   
    }
    public bool AddItem(Item item)
    {
        if (IsFull()) return false;

        items.Add(item);
        RefeshUI();
        return true;
    }
    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            RefeshUI();
            return true;
        }
        return false;
    }
    public bool IsFull()
    {
        return items.Count >= itemSlots.Length;
    }







}
