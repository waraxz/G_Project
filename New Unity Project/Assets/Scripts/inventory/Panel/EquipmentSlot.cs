
public class EquipmentSlot : ItemSlot
{
    public EquipmentType EquipmentType;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = EquipmentType.ToString() + " Slot";
    }

    public override bool CanReceiveItem(Item item)
    {
        if (item == null)
            return true;

        Equippable equippableItem = item as Equippable;
        return equippableItem != null && equippableItem.equipmentType == EquipmentType;
    }
}
