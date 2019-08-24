

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
}
