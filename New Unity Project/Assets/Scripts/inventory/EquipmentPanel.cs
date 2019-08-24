
using UnityEngine;
using System;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equimentSlotParent;
    [SerializeField] Equipmentslot[] equipmentSlots;

    public event Action<Item> onItemRightClickedEvent;

    private void Awake()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].onRightClickEvent += onItemRightClickedEvent;

        }
    }

    private void OnValidate()
    {
        equipmentSlots = equimentSlotParent.GetComponentsInChildren<Equipmentslot>();
    }

    public bool AddItem(Equippable item, out Equippable previousItem)
    {
        for(int i=0; i < equipmentSlots.Length; i++)
        {
            if(equipmentSlots[i].equipmentType == item.equipmentType)
            {
                previousItem = (Equippable)equipmentSlots[i].item;
                equipmentSlots[i].item = item;
                return true;
            }
            
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(Equippable item)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].item = item)
            {
                equipmentSlots[i].item = null;
                return true;
            }

        }
        return false;
    }

}

