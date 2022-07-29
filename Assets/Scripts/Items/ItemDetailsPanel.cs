using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailsPanel : MonoBehaviour
{
    public Item item;

    public Button EquipButton;
    public Button TossButton;
    public Button ExitButton;
    private GameObject Player;
    public GameObject Panel;

    public Sprite DefaultCross;

    void Start()
    {
        TossButton.onClick.AddListener(TossItem);
        EquipButton.onClick.AddListener(EquipItem);
        ExitButton.onClick.AddListener(ExitPanel);
    }

    private void TossItem()
    {
        Player = GameObject.Find("Player");
        PlayerScript playerScript = Player.GetComponent<PlayerScript>();
        playerScript.inventory.RemoveItem(item);

        Panel.SetActive(false);
    }

    private void EquipItem()
    {
        Player = GameObject.Find("Player");
        PlayerScript playerScript = Player.GetComponent<PlayerScript>();



        if (item.IsHealing())
        {
            if (playerScript.CurrHP == playerScript.player.MaxHp && playerScript.CurrMP == playerScript.player.MaxMp)
            {
                Debug.Log("U have full HP and MP");
            }
            else
            {
                if (playerScript.CurrHP + item.HealPower > playerScript.player.MaxHp)
                {
                    playerScript.CurrHP = playerScript.player.MaxHp;
                    playerScript.inventory.RemoveItem(item);
                }
                else
                {
                    playerScript.CurrHP += item.HealPower;
                    playerScript.inventory.RemoveItem(item);
                }
                if (playerScript.CurrMP + item.HealPower > playerScript.player.MaxMp)
                {
                    playerScript.CurrMP = playerScript.player.MaxMp;
                    playerScript.inventory.RemoveItem(item);
                }
                else
                {
                    playerScript.CurrMP += item.HealPower;
                    playerScript.inventory.RemoveItem(item);
                }
            }

            return;
        }

        switch (item.itemType)
        {
            default:
            case Item.ItemType.Helmet:
                {
                    if (!item.isEquiped)
                    {
                        GameObject helmetObj = GameObject.Find("HeadSlot");
                        EqSlotScript eqSlotScript = helmetObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject helmetObj = GameObject.Find("HeadSlot");
                        EqSlotScript eqSlotScript = helmetObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Helmet2:
                {
                    if (!item.isEquiped)
                    {
                        GameObject helmetObj = GameObject.Find("HeadSlot");
                        EqSlotScript eqSlotScript = helmetObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject helmetObj = GameObject.Find("HeadSlot");
                        EqSlotScript eqSlotScript = helmetObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Helmet3:
                {
                    if (!item.isEquiped)
                    {
                        GameObject helmetObj = GameObject.Find("HeadSlot");
                        EqSlotScript eqSlotScript = helmetObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject helmetObj = GameObject.Find("HeadSlot");
                        EqSlotScript eqSlotScript = helmetObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Sword:
                {

                    if (!item.isEquiped)
                    {
                        GameObject swordtObj = GameObject.Find("RightHandSlot");
                        EqSlotScript eqSlotScript = swordtObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        Debug.Log(item.name);
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject helmetObj = GameObject.Find("RightHandSlot");
                        EqSlotScript eqSlotScript = helmetObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Sword2:
                {

                    if (!item.isEquiped)
                    {
                        GameObject swordtObj = GameObject.Find("RightHandSlot");
                        EqSlotScript eqSlotScript = swordtObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        Debug.Log(item.name);
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject helmetObj = GameObject.Find("RightHandSlot");
                        EqSlotScript eqSlotScript = helmetObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Sword3:
                {

                    if (!item.isEquiped)
                    {
                        GameObject swordtObj = GameObject.Find("RightHandSlot");
                        EqSlotScript eqSlotScript = swordtObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        Debug.Log(item.name);
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject helmetObj = GameObject.Find("RightHandSlot");
                        EqSlotScript eqSlotScript = helmetObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Armor:
                {

                    if (!item.isEquiped)
                    {
                        GameObject armortObj = GameObject.Find("TorsoSlot");
                        EqSlotScript eqSlotScript = armortObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject helmetObj = GameObject.Find("TorsoSlot");
                        EqSlotScript eqSlotScript = helmetObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;

                }
            case Item.ItemType.Armor2:
                {

                    if (!item.isEquiped)
                    {
                        GameObject armortObj = GameObject.Find("TorsoSlot");
                        EqSlotScript eqSlotScript = armortObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject helmetObj = GameObject.Find("TorsoSlot");
                        EqSlotScript eqSlotScript = helmetObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;

                }
            case Item.ItemType.Armor3:
                {

                    if (!item.isEquiped)
                    {
                        GameObject armortObj = GameObject.Find("TorsoSlot");
                        EqSlotScript eqSlotScript = armortObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject helmetObj = GameObject.Find("TorsoSlot");
                        EqSlotScript eqSlotScript = helmetObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;

                }
            case Item.ItemType.Axe:
                {

                    if (!item.isEquiped)
                    {
                        GameObject axeObj = GameObject.Find("RightHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject axeObj = GameObject.Find("RightHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Axe2:
                {

                    if (!item.isEquiped)
                    {
                        GameObject axeObj = GameObject.Find("RightHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject axeObj = GameObject.Find("RightHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Axe3:
                {

                    if (!item.isEquiped)
                    {
                        GameObject axeObj = GameObject.Find("RightHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject axeObj = GameObject.Find("RightHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Boots:
                {
                    if (!item.isEquiped)
                    {
                        GameObject bootsObj = GameObject.Find("BootsSlot");
                        EqSlotScript eqSlotScript = bootsObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject bootsObj = GameObject.Find("BootsSlot");
                        EqSlotScript eqSlotScript = bootsObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Boots2:
                {
                    if (!item.isEquiped)
                    {
                        GameObject bootsObj = GameObject.Find("BootsSlot");
                        EqSlotScript eqSlotScript = bootsObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject bootsObj = GameObject.Find("BootsSlot");
                        EqSlotScript eqSlotScript = bootsObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Boots3:
                {
                    if (!item.isEquiped)
                    {
                        GameObject bootsObj = GameObject.Find("BootsSlot");
                        EqSlotScript eqSlotScript = bootsObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject bootsObj = GameObject.Find("BootsSlot");
                        EqSlotScript eqSlotScript = bootsObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Shield:
                {

                    if (!item.isEquiped)
                    {
                        GameObject axeObj = GameObject.Find("LeftHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject axeObj = GameObject.Find("LeftHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Shield2:
                {

                    if (!item.isEquiped)
                    {
                        GameObject axeObj = GameObject.Find("LeftHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject axeObj = GameObject.Find("LeftHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Shield3:
                {

                    if (!item.isEquiped)
                    {
                        GameObject axeObj = GameObject.Find("LeftHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject axeObj = GameObject.Find("LeftHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Wand:
                {

                    if (!item.isEquiped)
                    {
                        GameObject axeObj = GameObject.Find("LeftHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject axeObj = GameObject.Find("LeftHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Wand2:
                {

                    if (!item.isEquiped)
                    {
                        GameObject axeObj = GameObject.Find("LeftHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject axeObj = GameObject.Find("LeftHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
            case Item.ItemType.Wand3:
                {

                    if (!item.isEquiped)
                    {
                        GameObject axeObj = GameObject.Find("LeftHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();

                        if (eqSlotScript.SlotIsTaken)
                        {
                            Item item = eqSlotScript.GetItem();
                            item.isEquiped = false;
                            playerScript.inventory.AddItem(item);
                            eqSlotScript.item = null;
                        }
                        eqSlotScript.item = item;
                        eqSlotScript.image.sprite = item.GetSprite();
                        item.isEquiped = true;
                        playerScript.inventory.RemoveItem(item);
                    }
                    else if (playerScript.inventory.GetItemList().Count <= 35)
                    {
                        GameObject axeObj = GameObject.Find("LeftHandSlot");
                        EqSlotScript eqSlotScript = axeObj.GetComponent<EqSlotScript>();
                        eqSlotScript.image.sprite = getCross();
                        item.isEquiped = false;
                        eqSlotScript.item = null;
                        playerScript.inventory.AddItem(item);
                    }
                    ExitPanel();
                    break;
                }
        }

    }

    private Sprite getCross()
    {
        return ItemAssest.Instance.DefaultCross;
    }

    private void ExitPanel()
    {
        Panel.SetActive(false);
    }

}
