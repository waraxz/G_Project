
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;

    [SerializeField] Image draggableItem;
    [SerializeField] Text draggableText;

    private ItemSlot draggedSlot;



    private void Awake()
    {
        //คลิก equip item ใน inventory ไปยัง equipment Panel
           inventory.onLeftClickEvent += Equip;
        // คลิกขวาเพื่อถอดอาวุธออก
           equipmentPanel.onLeftClickEvent += Unequip;

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

    private void Equip(ItemSlot itemSlot)
    {
        Equippable equippable = itemSlot.item as Equippable;
        if (equippable != null)
        {
            Equip(equippable);
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

    private void Unequip(ItemSlot itemSlot)
    {
        Equippable equippable = itemSlot.item as Equippable;
        if (equippable != null)
        {
            Unequip(equippable);
        }
    }

    private void EquipmentPanelLeftClick(ItemSlot itemSlot)
    {
        if (itemSlot.item is Equippable)
        {
            Unequip((Equippable)itemSlot.item);
        }
    }

  


    private void BeginDrag(ItemSlot itemSlot)
    {
        if (itemSlot.item != null)
        {
            
            draggedSlot = itemSlot;
            draggableItem.sprite = itemSlot.item.tk_icon;
            draggableText.text = itemSlot.item.tk_itemName;
            draggableItem.transform.position = Input.mousePosition;
            draggableText.enabled = true;
            draggableItem.enabled = true;
            
        }
    }

    private void Drag(ItemSlot itemSlot)
    {
        if(draggableItem.enabled)
        draggableItem.transform.position = Input.mousePosition;
    }

    private void EndDrag(ItemSlot itemSlot)
    {
        draggedSlot = null;
        draggableItem.enabled = false;
        draggableText.enabled = false;
    }

    private void Drop(ItemSlot dropItemSlot)
    {

        if (dropItemSlot.CanReceiveItem(draggedSlot.item) && draggedSlot.CanReceiveItem(dropItemSlot.item))
        {
            Item draggedItem = draggedSlot.item;
            draggedSlot.item = dropItemSlot.item;
            dropItemSlot.item = draggedItem;


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
            inventory.AddItem(item);
        
        }
    }
}
