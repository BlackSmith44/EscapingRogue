using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlotClickHandler : MonoBehaviour, IPointerClickHandler
{
    private Button button;

    public GameObject ItemPanel;
    public Text Name;
    public Text Description;
    public Text Stats;
    public Image ItemImg;
    public Text Equip;

    private GameObject Player;
    private List<Item> itemList;

    void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        ItemPanel.SetActive(false);
    }

    private void FindItem(Button button)
    {
        if (!ItemPanel.activeSelf)
        {
            string[] numbers = button.name.Split('-');
            string position = numbers[0];
            string index = numbers[1];
            Player = GameObject.Find("Player");
            PlayerScript playerScript = Player.GetComponent<PlayerScript>();
            itemList = playerScript.inventory.GetItemList();
            int a = 1;
            foreach (Item item in itemList)
            {
                if (item.ID == int.Parse(index) && a == int.Parse(position))
                {
                    SetDescription(item);
                    break;
                }
                a++;
            }
        }
    }

    private void SetDescription(Item item)
    {
        ItemImg.sprite = item.GetSprite();
        Name.text = item.name;
        Description.text = item.description;
        Stats.text = GetStatsText(item);
        ItemDetailsPanel itemDetailsPanel = ItemPanel.GetComponent<ItemDetailsPanel>();
        itemDetailsPanel.item = item;
        if (item.IsHealing())
        {
            Equip.text = "Use";
        }
        else
        {
            Equip.text = "Equip";
        }
        ItemPanel.SetActive(true);
    }

    private string GetStatsText(Item item)
    {
        string text;
        text = "Stats:\n";
        if (item.IsHealing())
        {
            text += "HealingPower: " + item.HealPower;
        }
        else
        {
            if (item.STR != 0) text += "STR: " + item.STR + "\n";
            if (item.DEX != 0) text += "DEX: " + item.DEX + "\n";
            if (item.VIT != 0) text += "VIT: " + item.VIT + "\n";
            if (item.INT != 0) text += "INT: " + item.INT + "\n";
        }
        return text;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            FindItem(button);
        }
    }

}
