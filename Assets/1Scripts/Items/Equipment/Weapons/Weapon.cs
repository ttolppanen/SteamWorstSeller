using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment
{

    public float damage;
    public DamageType damageType;
    public WeaponType weaponType;
    public Animator animator { get; set; }

    public Weapon(string itemName, Sprite inventoryPicture, float weight, float damage) : base(itemName, inventoryPicture, weight)
    {
        this.damage = damage;
    }

    public void Hit() { animator.SetTrigger("Hit"); }
    public void BeginBlocking() { animator.SetBool("Is blocking", true); }
    public void StopBlocking() { animator.SetBool("Is blocking", false); }
}

public enum DamageType { Cut, Blunt, Piercing}
public enum WeaponType { Unarmed, Light, Medium, Heavy} // Paremmat nimet...
