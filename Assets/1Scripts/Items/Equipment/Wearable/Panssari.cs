using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New armor", menuName = "Item/Equipment/Armor")]
public class Armor : Equipment
{
    public float defence;

    public Armor(string itemName, float weight, float defence, Sprite inventoryPicture) : base(itemName, inventoryPicture, weight)
    {
        this.defence = defence;
    }
}
