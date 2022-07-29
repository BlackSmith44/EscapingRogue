using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChestScript : MonoBehaviour
{

    public GameObject chestClosed;
    public GameObject chestOpen;
    private GameObject LootUIPanel;
    private GameObject Canvas;
    private GameObject Self;
    private GameObject Player;

    public EventHandler OnItemListChanged;

    private List<Item> lootList;
    private List<Item> lootedItemList;
    private Item tempItem;
    public int num; 

    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        if (Canvas != null)
        {
            LootUIPanel = FindObject(Canvas, "LootPanelUI");
        }
        Player = GameObject.Find("Player");
        chestClosed.SetActive(true);
        chestOpen.SetActive(false);
        lootList = new List<Item>();

        num = UnityEngine.Random.Range(1, 5);

        for (int i = 0; i < num; i++)
        {
            tempItem = ItemAssest.Instance.getRandItem();
            AddItem(tempItem);
        }
        Self = this.gameObject;
    }

    public static GameObject FindObject(GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }

    public List<Item> GetItemList()
    {
        return lootList;
    }

    public void OpenChest()
    {
        chestClosed.SetActive(false);
        chestOpen.SetActive(true);

        LootUI lootUI = LootUIPanel.GetComponent<LootUI>();

        lootUI.SetInventory(Self);
        LootUIPanel.SetActive(true);
    }

    public void AddItem(Item item)
    {
        lootList.Add(item);
        
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        try
        {
            lootList.Remove(item);
        }
        catch (InvalidOperationException e)
        {
            Debug.Log(e);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void LootItems(int[,] id_tab)
    {
        lootedItemList = new List<Item>();
        for (int i = 7; i >= 0; i--)
        {
            int j = 1;
            foreach (Item invItem in lootList)
            {
                if (invItem.ID == id_tab[i, 1] && j == id_tab[i, 0])
                {
                    try
                    {
                        lootedItemList.Add(invItem);
                    }
                    catch (InvalidOperationException e)
                    {
                        Debug.Log(e);
                    }
                }
                j++;
            }
        }
        Player = GameObject.Find("Player");
        PlayerScript playerScript = Player.GetComponent<PlayerScript>();
        if (playerScript.inventory.GetItemList().Count + lootedItemList.Count > 35)
        {
            int counter = playerScript.inventory.GetItemList().Count;
            foreach (Item item in lootedItemList)
            {
                if (counter < 35)
                {
                    playerScript.inventory.AddItem(item);
                    RemoveItem(item);
                    counter++;
                }
                else break;
            }
        }
        else
        {
            foreach (Item item in lootedItemList)
            {
                playerScript.inventory.AddItem(item);
                RemoveItem(item);
            }
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }


}
