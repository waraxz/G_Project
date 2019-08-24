
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;

    private void Awake()
    {
           inventory.onItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.onItemRightClickedEvent += UnEquiqFromEquipPanel;
    }

    private void EquipFromInventory(Item item)
    {
        if(item is Equippable)
        {
            Equip((Equippable)item);
        }
    }
    private void UnEquiqFromEquipPanel(Item item)
    {
        if(item is Equippable)
        {
            Unequip((Equippable)item);
            
        }
    }

    public void Equip(Equippable item)
    {
        if (inventory.RemoveItem(item))
        {
            Equippable previousItem;
            if(equipmentPanel.AddItem(item,out previousItem))
            {
                if(previousItem != null)
                {
                    inventory.AddItem(previousItem);
                }
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }
    public void Unequip(Equippable item)
    {
        if(!inventory.IsFull()&& equipmentPanel.RemoveItem(item))
        {
            inventory.AddItem(item);
        
        }
    }
}
