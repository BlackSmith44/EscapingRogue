using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private List<Item> itemList;
    public event EventHandler OnItemListChanged;
    public Inventory()
    {
        itemList = new List<Item>();
    }
    public void AddItem(Item item)
    {
        if (itemList.Count < 35)
        {
            itemList.Add(item);
            OnItemListChanged?.Invoke(this, EventArgs.Empty); 
        }
    }
    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public List<Item> GetItemList()
    {
        return itemList;
    }
}
