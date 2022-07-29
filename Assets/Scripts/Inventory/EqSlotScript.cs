using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EqSlotScript : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    public GameObject ItemPanel;
    public Text Name;
    public Text Description;
    public Text Stats;
    public Image ItemImg;
    public Text Equip;
    public Image image;
    public bool SlotIsTaken;

    void Update()
    {
        if (item != null)
        {
            SlotIsTaken = true;
        }
        else
        {
            SlotIsTaken = false;
        }
    }

    private void SetDescription(Item item)
    {
        if (item != null)
        {
            ItemImg.sprite = item.GetSprite();
            Name.text = item.name;
            Description.text = item.description;
            Stats.text = GetStatsText(item);
            ItemDetailsPanel itemDetailsPanel = ItemPanel.GetComponent<ItemDetailsPanel>();
            itemDetailsPanel.item = item;
            Equip.text = "Unequip";
            ItemPanel.SetActive(true);
        }
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
            SetDescription(item);
        }
    }

    public Item GetItem()
    {
        return item;
    }
}
