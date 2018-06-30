using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllStats : MonoBehaviour {

    public static AllStats instance;

    public Dictionary<PlayerProperties, int> allStats = new Dictionary<PlayerProperties, int>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        allStats[PlayerProperties.TotalDefence] = 0;
        allStats[PlayerProperties.TypeOfWeaponInHand] = (int)WeaponType.Unarmed;
    }

    public void UpdatePlayerStats()
    {
        allStats[PlayerProperties.TotalDefence] = CalculateTotalDefence(); //Koko defence

        if (Inventory.instance.GetWeaponInHand() != null) // Asetyyppi
        {
            allStats[PlayerProperties.TypeOfWeaponInHand] = (int)Inventory.instance.GetWeaponInHand().weaponType;
        }
        else
        {
            allStats[PlayerProperties.TypeOfWeaponInHand] = (int)WeaponType.Unarmed;
        }

        GetComponent<Animator>().SetInteger("Weapon type", allStats[PlayerProperties.TypeOfWeaponInHand]);//Asetetaan animaatioihin tieto asetyypistä
    }

    public int CalculateTotalDefence()
    {
        GameObject[] playersEquipment = Inventory.instance.equipment;
        int totalDefence = 0;
        for (int i = 0; i < (int)EquipmentType.Weapon; i++)
        {
            if (playersEquipment[i] != null)
            {
                totalDefence += ((Armor)playersEquipment[i].GetComponent<ItemProperties>().item).defence;
            }
        }
        return totalDefence;
    }
}

public enum PlayerProperties { TotalDefence, TypeOfWeaponInHand };
