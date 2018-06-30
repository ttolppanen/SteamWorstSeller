using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{

    public EquipmentType equipmentType;

    public Equipment(string itemName, Sprite inventoryPicture, float weight) : base(itemName, inventoryPicture, weight)
    {

    }
}

public enum EquipmentType { Head, Chest, Pants, Gloves, Weapon} //Kaulakoru, sormus......