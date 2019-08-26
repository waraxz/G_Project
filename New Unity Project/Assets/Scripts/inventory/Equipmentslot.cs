

public class Equipmentslot : ItemSlot
{
    public EquipmentType equipmentType;

    protected override void OnValidate()
    {
        //เชื่อมระหว่าง equipment slot กับ item slot
        base.OnValidate();
        //สร้างชื่อให้กับ slot
        gameObject.name = equipmentType.ToString() + "Slot";
    }

    public override bool CanReceiveItem(Item item)
    {
        if (item == null) return true;

        Equippable equippableItem = item as Equippable;
        return equippableItem != null && equippableItem.equipmentType == equipmentType;
    }
}
