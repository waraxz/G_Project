using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemContainer : MonoBehaviour, IItemContainer
{
    public List<ItemSlot> ItemSlots;

    private int unlockSlot = 1;
    public int UnlockSlot
    {
        get
        {
            return unlockSlot;
        }
        // you can additionally make the setter private so only this class
        // can change the value while other classes have only read permissions
        /*private*/
        set
        {
            unlockSlot = value;

            UpdateItemSlots();
        }
    }

    public event Action<BaseItemSlot> OnPointerEnterEvent = slot => { };
    public event Action<BaseItemSlot> OnPointerExitEvent = slot => { };
    public event Action<BaseItemSlot> OnRightClickEvent = slot => { };
    public event Action<BaseItemSlot> OnBeginDragEvent = slot => { };
    public event Action<BaseItemSlot> OnEndDragEvent = slot => { };
    public event Action<BaseItemSlot> OnDragEvent = slot => { };
    public event Action<BaseItemSlot> OnDropEvent = slot => { };

    protected virtual void OnValidate()
    {
        GetComponentsInChildren(includeInactive: true, result: ItemSlots);
        
    }


    private void UpdateItemSlots()
    {
        for (var i = 0; i < ItemSlots.Count / 5 * unlockSlot; i++)
        {
            // Before adding callbacks remove them
            // this is valid even if they were not added before
            // but makes sure they are added only exactly once
            ItemSlots[i].OnPointerEnterEvent -= OnPointerEnterEvent;
            ItemSlots[i].OnPointerExitEvent -= OnPointerExitEvent;
            ItemSlots[i].OnRightClickEvent -= OnRightClickEvent;
            ItemSlots[i].OnBeginDragEvent -= OnBeginDragEvent;
            ItemSlots[i].OnEndDragEvent -= OnEndDragEvent;
            ItemSlots[i].OnDragEvent -= OnDragEvent;
            ItemSlots[i].OnDropEvent -= OnDropEvent;

            // add your callback events .. no need for this complex lambda construct
            ItemSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            ItemSlots[i].OnPointerExitEvent += OnPointerExitEvent;
            ItemSlots[i].OnRightClickEvent += OnRightClickEvent;
            ItemSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            ItemSlots[i].OnEndDragEvent += OnEndDragEvent;
            ItemSlots[i].OnDragEvent += OnDragEvent;
            ItemSlots[i].OnDropEvent += OnDropEvent;
        }
    }
    protected virtual void Start()
    {
        UpdateItemSlots();
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            UnlockSlot++;
            // for reading in this case it doesn't matter
            // but for being consequent I would also use the property here
            Debug.Log(UnlockSlot);
        }
    }

    //private void EventHelper(BaseItemSlot itemSlot, Action<BaseItemSlot> action)
    //{
    //    if (action != null)
    //        action(itemSlot);
    //}

    public virtual bool CanAddItem(Item item, int amount = 1)
    {
        int freeSpaces = 0;

        foreach (ItemSlot itemSlot in ItemSlots)
        {
            if (itemSlot.Item == null || itemSlot.Item.ID == item.ID)
            {
                freeSpaces += item.MaxStacks - itemSlot.Amount;
            }
        }
        return freeSpaces >= amount;
    }

    public virtual bool AddItem(Item item)
    {
        for (int i = 0; i < ItemSlots.Count / 5 * unlockSlot; i++)
        {
            if (ItemSlots[i].CanAddStack(item))
            {
                ItemSlots[i].Item = item;
                ItemSlots[i].Amount++;
                return true;

            }
        }

        for (int i = 0; i < ItemSlots.Count / 5 * unlockSlot; i++)
        {
            if (ItemSlots[i].Item == null)
            {
                if (item.ID == item.ID)
                {
                    ItemSlots[i].Item = item;
                    ItemSlots[i].Amount++;
                    return true;
                }

            }
        }
        return false;
    }

    public virtual bool RemoveItem(Item item)
    {
        for (int i = 0; i < ItemSlots.Count; i++)
        {
            if (ItemSlots[i].Item == item)
            {
                ItemSlots[i].Amount--;
                return true;
            }
        }
        return false;
    }

    public virtual Item RemoveItem(string itemID)
    {
        for (int i = 0; i < ItemSlots.Count; i++)
        {
            Item item = ItemSlots[i].Item;
            if (item != null && item.ID == itemID)
            {
                ItemSlots[i].Amount--;
                return item;
            }
        }
        return null;
    }

    public virtual int ItemCount(string itemID)
    {
        int number = 0;

        for (int i = 0; i < ItemSlots.Count; i++)
        {
            Item item = ItemSlots[i].Item;
            if (item != null && item.ID == itemID)
            {
                number += ItemSlots[i].Amount;
            }
        }
        return number;
    }

    public void Clear()
    {
        for (int i = 0; i < ItemSlots.Count; i++)
        {
            if (ItemSlots[i].Item != null && Application.isPlaying)
            {
                ItemSlots[i].Item.Destroy();
            }
            ItemSlots[i].Item = null;
            ItemSlots[i].Amount = 0;
        }
    }




}
