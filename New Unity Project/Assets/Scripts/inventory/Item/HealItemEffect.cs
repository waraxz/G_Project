using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Heal")]
public class HealItemEffect : UsableItemEffect
{
    public int HealAmount;

    public override void ExecuteEffect(UsableItem usableItem, PlayerHealthManager character)
    {

        //เพิ่มเลือด
        character.playerCurrentHealth += HealAmount;
    }

    public override string GetDescription()
    {
        return "Heals for " + HealAmount + " health.";
    }
}