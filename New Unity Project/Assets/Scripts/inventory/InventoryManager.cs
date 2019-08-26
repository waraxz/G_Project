
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;

    [SerializeField] Image draggableItem;

    private ItemSlot dragItemSlot;

    private void Awake()
    {
        //คลิก equip item ใน inventory ไปยัง equipment Panel
           inventory.onLeftClickEvent += InventoryRightClick;
        // คลิกขวาเพื่อถอดอาวุธออก
           equipmentPanel.onLeftClickEvent += EquipmentPanelLeftClick;

        //อยากให้ทำอะไร ตอนเม้าส์ชี้
        // inventory.onPointerEnterEvent += function ที่ต้องการ
        // equipmentPanel.onPointerEnterEvent+= function ที่ต้องการ

        // inventory.onPointerExitEvent += function ที่ต้องการ
        // equipmentPanel.onPointerExitEvent+= function ที่ต้องการ

        inventory.onBeginDragEvent += BeginDrag;
        equipmentPanel.onBeginDragEvent += BeginDrag;

        inventory.onEndDragEvent += EndDrag;
        equipmentPanel.onEndDragEvent += EndDrag;
        // Drag
        inventory.onDragEvent += Drag;
        equipmentPanel.onDragEvent += Drag;
        // Drop
        //inventory.onDropEvent += Drop;
        //equipmentPanel.onDropEvent += Drop;
        //dropItemArea.OnDropEvent += DropItemOutsideUI;
    }

    private void InventoryRightClick(ItemSlot itemSlot)
    {
        if (itemSlot.item is Equippable)
        {
            Equip((Equippable)itemSlot.item);
        }
        //else if (itemslot.item is usableitem)
        //{
        //    usableitem usableitem = (usableitem)itemslot.item;
        //    usableitem.use(this);

        //    if (usableitem.isconsumable)
        //    {
        //        itemslot.amount--;
        //        usableitem.destroy();
        //    }
        //}
    }

    private void EquipmentPanelLeftClick(ItemSlot itemSlot)
    {
        if (itemSlot.item is Equippable)
        {
            Unequip((Equippable)itemSlot.item);
        }
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

    private void BeginDrag(ItemSlot itemSlot)
    {
        if (itemSlot.item != null)
        {
            dragItemSlot = itemSlot;
            draggableItem.sprite = itemSlot.item.tk_icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.gameObject.SetActive(true);
        }
    }

    private void Drag(ItemSlot itemSlot)
    {
        draggableItem.transform.position = Input.mousePosition;
    }

    private void EndDrag(ItemSlot itemSlot)
    {
        dragItemSlot = null;
        draggableItem.gameObject.SetActive(false);
    }

    private void Drop(ItemSlot dropItemSlot)
    {
         if (dragItemSlot == null) return;

         if(dropItemSlot.CanReceiveItem(dragItemSlot.item) && dragItemSlot.CanReceiveItem(dropItemSlot.item))
        {
            Equippable dragItem = dragItemSlot.item as Equippable;
            Equippable dropItem = dropItemSlot.item as Equippable;

            if(dragItemSlot is Equipmentslot)
            {

            }
        }

        //    if (dropItemSlot.CanAddStack(dragItemSlot.Item))
        //    {
        //        AddStacks(dropItemSlot);
        //    }
        //    else if (dropItemSlot.CanReceiveItem(dragItemSlot.Item) && dragItemSlot.CanReceiveItem(dropItemSlot.Item))
        //    {
        //        SwapItems(dropItemSlot);
        //    }
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
        //ถ้า inventory ไม่เต็มและถอดอาวุธออก
        if(!inventory.IsFull()&& equipmentPanel.RemoveItem(item))
        {
            // เพิ่มไอเท็มกลับเข้าไปยัง inventory

        
        }
    }
}
