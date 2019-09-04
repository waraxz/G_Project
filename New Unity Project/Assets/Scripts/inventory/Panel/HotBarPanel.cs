using UnityEngine;
using System;
using System.Collections.Generic;

public class HotBarPanel : MonoBehaviour
{
    public BaseItemSlot[] hotBarSlots;
    [SerializeField] Transform hotBarParent;
    public Inventory inv;
    public InventoryManager invManager;


    private void OnValidate()
    {
        hotBarSlots = hotBarParent.GetComponentsInChildren<ItemSlot>();


    }

    private void Update()
    {
        for (int i = 0; i < hotBarSlots.Length; i++)
        {
            if (inv.ItemSlots[i].Item != null || inv.ItemSlots[i].Amount != 0)
            {

                hotBarSlots[i].Item = inv.ItemSlots[i].Item;
                hotBarSlots[i].Amount = inv.ItemSlots[i].Amount;

            }
            else
            {
                hotBarSlots[i].Item = null;
                hotBarSlots[i].Amount = 0;

            }
            if (Input.GetKeyUp(inv.ItemSlots[i].keyCode))
            {
                invManager.RightClickorPresstoUse(inv.ItemSlots[i]);
            }

        }
    }



}


