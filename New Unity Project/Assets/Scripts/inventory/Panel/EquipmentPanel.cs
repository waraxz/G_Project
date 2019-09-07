using System;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
    public EquipmentSlot[] EquipmentSlots;
    [SerializeField] Transform equipmentSlotsParent;

    public event Action<BaseItemSlot> OnPointerEnterEvent = slot => { };
    public event Action<BaseItemSlot> OnPointerExitEvent = slot => { };
    public event Action<BaseItemSlot> OnRightClickEvent = slot => { };
    public event Action<BaseItemSlot> OnBeginDragEvent = slot => { };
    public event Action<BaseItemSlot> OnEndDragEvent = slot => { };
    public event Action<BaseItemSlot> OnDragEvent = slot => { };
    public event Action<BaseItemSlot> OnDropEvent = slot => { };

    private void Start()
    {
        for (int i = 0; i < EquipmentSlots.Length; i++)
        {
            //EquipmentSlots[i].OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
            //EquipmentSlots[i].OnPointerExitEvent += slot => OnPointerExitEvent(slot);
            EquipmentSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            EquipmentSlots[i].OnPointerExitEvent += OnPointerExitEvent;
            EquipmentSlots[i].OnRightClickEvent += OnRightClickEvent;
            EquipmentSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            EquipmentSlots[i].OnEndDragEvent += OnEndDragEvent;
            EquipmentSlots[i].OnDragEvent += OnDragEvent;
            EquipmentSlots[i].OnDropEvent += OnDropEvent;
        }
    }

    private void OnValidate()
    {
        EquipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public bool AddItem(Equippable item, out Equippable previousItem)
    {
        for (int i = 0; i < EquipmentSlots.Length; i++)
        {
            if (EquipmentSlots[i].EquipmentType == item.equipmentType)
            {
                previousItem = (Equippable)EquipmentSlots[i].Item;
                EquipmentSlots[i].Item = item;
                EquipmentSlots[i].Amount = 1;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(Equippable item)
    {
        for (int i = 0; i < EquipmentSlots.Length; i++)
        {
            if (EquipmentSlots[i].Item == item)
            {
                EquipmentSlots[i].Item = null;
                EquipmentSlots[i].Amount = 0;
                return true;
            }
        }
        return false;
    }
}

