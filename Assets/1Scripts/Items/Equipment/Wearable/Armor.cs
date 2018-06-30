using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New armor", menuName = "Item/Equipment/Armor")]
public class Armor : Equipment
{
    public int defence;

    public Armor(string itemName, float weight, int defence, Sprite inventoryPicture) : base(itemName, inventoryPicture, weight)
    {
        this.defence = defence;
    }
}
