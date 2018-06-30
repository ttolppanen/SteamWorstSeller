using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject{

    public string itemName;
    public Sprite inventoryPicture;
    public float weight;

    public Item(string itemName, Sprite inventoryPicture, float weight)
    {
        this.itemName = itemName;
        this.inventoryPicture = inventoryPicture;
        this.weight = weight;
    }
}