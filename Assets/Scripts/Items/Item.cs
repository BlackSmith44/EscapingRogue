using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string name;
    public string description;
    public int ID;

    public ItemType itemType;
    public enum ItemType
    {
        Sword,
        Sword2,
        Sword3,
        Shield,
        Shield2,
        Shield3,
        Axe,
        Axe2,
        Axe3,
        Armor,
        Armor2,
        Armor3,
        Helmet,
        Helmet2,
        Helmet3,
        Boots,
        Boots2,
        Boots3,
        Wand,
        Wand2,
        Wand3,
        Heal,
        Heal2,
    }

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword:     return ItemAssest.Instance.Sword;
            case ItemType.Sword2:    return ItemAssest.Instance.Sword2;
            case ItemType.Sword3:    return ItemAssest.Instance.Sword3;
            case ItemType.Shield:    return ItemAssest.Instance.Shield;
            case ItemType.Shield2:   return ItemAssest.Instance.Shield2;
            case ItemType.Shield3:   return ItemAssest.Instance.Shield3;
            case ItemType.Axe:       return ItemAssest.Instance.Axe;
            case ItemType.Axe2:      return ItemAssest.Instance.Axe2;
            case ItemType.Axe3:      return ItemAssest.Instance.Axe3;
            case ItemType.Armor:     return ItemAssest.Instance.Armor;
            case ItemType.Armor2:    return ItemAssest.Instance.Armor2;
            case ItemType.Armor3:    return ItemAssest.Instance.Armor3;
            case ItemType.Helmet:    return ItemAssest.Instance.Helmet;
            case ItemType.Helmet2:   return ItemAssest.Instance.Helmet2;
            case ItemType.Helmet3:   return ItemAssest.Instance.Helmet3;
            case ItemType.Boots:     return ItemAssest.Instance.Boots;
            case ItemType.Boots2:    return ItemAssest.Instance.Boots2;
            case ItemType.Boots3:    return ItemAssest.Instance.Boots3;
            case ItemType.Wand:      return ItemAssest.Instance.Wand;
            case ItemType.Wand2:      return ItemAssest.Instance.Wand2;
            case ItemType.Wand3:      return ItemAssest.Instance.Wand3;
            case ItemType.Heal:      return ItemAssest.Instance.Chicken;
            case ItemType.Heal2:     return ItemAssest.Instance.Pottion;


        }
    }

    public float STR;
    public float DEX;
    public float VIT;
    public float INT;

    public bool IsHealing()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword:
            case ItemType.Sword2:
            case ItemType.Sword3:
            case ItemType.Shield:
            case ItemType.Shield2:
            case ItemType.Shield3:
            case ItemType.Axe:
            case ItemType.Axe2:
            case ItemType.Axe3:
            case ItemType.Armor:
            case ItemType.Armor2:
            case ItemType.Armor3:
            case ItemType.Boots:
            case ItemType.Boots2:
            case ItemType.Boots3:
            case ItemType.Helmet:
            case ItemType.Helmet2:
            case ItemType.Helmet3:
            case ItemType.Wand:
            case ItemType.Wand2:
            case ItemType.Wand3:
                return false;
            case ItemType.Heal:
                return true;
            case ItemType.Heal2:
                return true;

        }
    }

    public int HealPower;

    public bool isEquiped;

    




}
