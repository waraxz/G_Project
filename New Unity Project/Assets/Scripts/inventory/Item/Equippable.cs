
using UnityEngine;

public enum EquipmentType
{
    Helmet,
    Mask,
    Armour,
    Boots,
    Garment,
    Weapon1,
    Weapon2,
    Accessory,

}

[CreateAssetMenu(fileName = "new equippable", menuName = "Items/Equippable")]
public class Equippable : Item
{

    public int strBonus;
    public int agiBonus;
    public int intBonus;
    public int vitBouns;
    public int dexBouns;
    public int luckBonus;
    [Space]
    public float strPercentBonus;
    public float agiPercentBonus;
    public float intPercentBonus;
    public float vitPercentBonus;
    public float dexPercentBonus;
    public float luckPercentBonus;
    [Space]
    public EquipmentType equipmentType;
    
}
