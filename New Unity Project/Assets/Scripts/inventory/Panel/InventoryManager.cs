
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    [Header("Public")]
    public Inventory Inventory;
    public EquipmentPanel EquipmentPanel;

    [Header("Serialize Field")]
    [SerializeField] Image draggableItem;
    [SerializeField] DropItemArea dropItemArea;
    //[SerializeField] ItemSaveManager itemSaveManager;

    private BaseItemSlot dragItemSlot;

    public PlayerHealthManager playerHP;

    private void Awake()
    {
        // Setup Events:
        // Right Click
        Inventory.OnRightClickEvent += RightClickorPresstoUse;
        EquipmentPanel.OnRightClickEvent += EquipmentPanelRightClick;
        // Pointer Enter


        // Pointer Exit


        // Begin Drag
        Inventory.OnBeginDragEvent += BeginDrag;
        EquipmentPanel.OnBeginDragEvent += BeginDrag;
        // End Drag
        Inventory.OnEndDragEvent += EndDrag;
        EquipmentPanel.OnEndDragEvent += EndDrag;
        // Drag
        Inventory.OnDragEvent += Drag;
        EquipmentPanel.OnDragEvent += Drag;
        // Drop
        Inventory.OnDropEvent += Drop;
        EquipmentPanel.OnDropEvent += Drop;
        dropItemArea.OnDropEvent += DropItemOutsideUI;
    }

    // TKคลิกขวาหรือกด 1-= เพื่อใช้ไอเท็ม
    public void RightClickorPresstoUse(BaseItemSlot itemSlot)
    {
        //สำหรับ item อาวุธ
        if (itemSlot.Item is Equippable)
        {

            Equip((Equippable)itemSlot.Item);
        }
        //สำหรับ item ใช้แล้วหาย
        else if (itemSlot.Item is UsableItem)
        {
           
            UsableItem usableItem = (UsableItem)itemSlot.Item;
            usableItem.Use(playerHP);
            // ถ้าไอเท็ม usableใช้งาน
            if (usableItem.IsConsumable)
            {
                // ลด amount
                itemSlot.Amount--;
                // ถ้าไม่มี amount จะทำลาย
                usableItem.Destroy();
            }
        }
        // ไอเท็มอื่นเพิ่มเข้าแล้วจะทำอะไรก็ทำ
    }
    // คลิกขวาใน slot ช่อง equip
    private void EquipmentPanelRightClick(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item is Equippable)
        {
            Unequip((Equippable)itemSlot.Item);
        }
    }

    //เริ่มคลิกเม้าส์เพื่อ....
    private void BeginDrag(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item != null)
        {
            dragItemSlot = itemSlot;
            draggableItem.sprite = itemSlot.Item.icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.gameObject.SetActive(true);
        }
    }
    //เริ่มคลิกและลากเม้าส์เพื่อ....
    private void Drag(BaseItemSlot itemSlot)
    {
        draggableItem.transform.position = Input.mousePosition;
    }
    //เริ่มปล่อยเม้าส์เพื่อ...
    private void EndDrag(BaseItemSlot itemSlot)
    {
        dragItemSlot = null;
        draggableItem.gameObject.SetActive(false);
    }
    //หากมีอะไรดรอป
    private void Drop(BaseItemSlot dropItemSlot)
    {
        if (dragItemSlot == null) return;

        if (dropItemSlot.CanAddStack(dragItemSlot.Item))
        {
            AddStacks(dropItemSlot);
        }
        else if (dropItemSlot.CanReceiveItem(dragItemSlot.Item) && dragItemSlot.CanReceiveItem(dropItemSlot.Item))
        {
            SwapItems(dropItemSlot);
        }
    }
    //เพิ่มจำนวนในสล็อตเดียวกัน
    private void AddStacks(BaseItemSlot dropItemSlot)
    {

        int numAddableStacks = dropItemSlot.Item.MaxStacks - dropItemSlot.Amount;
        int stacksToAdd = Mathf.Min(numAddableStacks, dragItemSlot.Amount);

        dropItemSlot.Amount += stacksToAdd;
        dragItemSlot.Amount -= stacksToAdd;
    }
    //เมื่อ slot นั้นมีไอเท็มและเราต้องการสลับไอเท็ม
    private void SwapItems(BaseItemSlot dropItemSlot)
    {
        Equippable dragEquipItem = dragItemSlot.Item as Equippable;
        Equippable dropEquipItem = dropItemSlot.Item as Equippable;


        Item draggedItem = dragItemSlot.Item;
        int draggedItemAmount = dragItemSlot.Amount;

        dragItemSlot.Item = dropItemSlot.Item;
        dragItemSlot.Amount = dropItemSlot.Amount;

        dropItemSlot.Item = draggedItem;
        dropItemSlot.Amount = draggedItemAmount;
    }

    private void DropItemOutsideUI()
    {
        if (dragItemSlot == null) return;


        dragItemSlot.Item.Destroy();
        dragItemSlot.Item = null;

    }

    private void DestroyItemInSlot(BaseItemSlot itemSlot)
    {

        if (itemSlot is EquipmentSlot)
        {
            Equippable equippableItem = (Equippable)itemSlot.Item;

        }

        itemSlot.Item.Destroy();
        itemSlot.Item = null;
    }

    public void Equip(Equippable item)
    {
        if (Inventory.RemoveItem(item))
        {
            Equippable previousItem;
            if (EquipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    Inventory.AddItem(previousItem);
                }
            }
            else
            {
                Inventory.AddItem(item);
            }
        }
    }

    public void Unequip(Equippable item)
    {
        if (Inventory.CanAddItem(item) && EquipmentPanel.RemoveItem(item))
        {


            Inventory.AddItem(item);
        }
    }
    

}
