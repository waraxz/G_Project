using UnityEngine;

public class Inventory : ItemContainer
{
    [SerializeField] protected Item[] startingItems;
    [SerializeField] protected Transform itemsParent;

    public InventoryManager invManager;
    protected override void OnValidate()
    {
        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: ItemSlots);

        if (!Application.isPlaying)
        {
            SetStartingItems();
        }
    }

    protected override void Awake()
    {
        base.Awake();
        SetStartingItems();
            
    }
    private void Start()
    {

       

    }
    // ใส่ไอเท็มตอนเริ่มต้นเล่นเกมส์ ใน hierarchy
    private void SetStartingItems()
    {
        Clear();
        foreach (Item item in startingItems)
        {    
          //ใส่ไอเท็มลงไป
            AddItem(item.GetCopy());
        }
    }
    private void Update()
    {
        for (int i = 0; i < ItemSlots.Count; i++)
            if (Input.GetKeyUp(ItemSlots[i].keyCode))
            {
                invManager.RightClickorPresstoUse(ItemSlots[i]);
            }
    }
}
