using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new consumable", menuName = "Items/Useable Item" )]
public class UsableItem : Item
{
    public List<UsableItemEffect> Effects;


    public virtual void Use(PlayerHealthManager character)
    {
        foreach (UsableItemEffect effect in Effects)
        {
            effect.ExecuteEffect(this, character);
        }
    }

    //public override string getitemtype()
    //{
    //    return isconsumable ? "consumable" : "usable";
    //}


}
