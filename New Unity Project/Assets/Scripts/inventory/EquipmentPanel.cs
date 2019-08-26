
using UnityEngine;
using System;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equimentSlotParent;
    [SerializeField] Equipmentslot[] equipmentSlots;

    public event Action<ItemSlot> onPointerEnterEvent;
    public event Action<ItemSlot> onPointerExitEvent;
    public event Action<ItemSlot> onLeftClickEvent;
    public event Action<ItemSlot> onBeginDragEvent;
    public event Action<ItemSlot> onEndDragEvent;
    public event Action<ItemSlot> onDragEvent;
    public event Action<ItemSlot> onDropEvent;

    private void Start()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].onPointerEnterEvent += onPointerEnterEvent;
            equipmentSlots[i].onPointerExitEvent += onPointerExitEvent;
            equipmentSlots[i].onLeftClickEvent += onLeftClickEvent;
            equipmentSlots[i].onBeginDragEvent += onBeginDragEvent;
            equipmentSlots[i].onEndDragEvent += onEndDragEvent;
            equipmentSlots[i].onDragEvent += onDragEvent;
            equipmentSlots[i].onDropEvent += onDropEvent;


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
            if(equipmentSlots[i].equipmentType == item.equipmentType)
            {
                if (equipmentSlots[i].item = item)
                {

                    equipmentSlots[i].item = null;
                    return true;
                }
            }
          

        }
        return false;
    }

}

