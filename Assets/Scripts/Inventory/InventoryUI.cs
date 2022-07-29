using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    private Inventory inventory;
    public Transform itemSlotContainer;
    public Transform itemSlotTemp;

    private GameObject panel;
    public Button ExitEqButtom;

    //public Text text;
    private void Start()
    {
        panel = this.gameObject;
        ExitEqButtom.onClick.AddListener(EqClose);
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }
    public void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemp) continue;
            Destroy(child.gameObject);
        }
        int line = 1;
        int itemsNumber = 1;

        int x = -180;
        int y = 100;
        int shiftX = 45;
        int shiftY = 0;
        foreach (Item item in inventory.GetItemList())
        {
            if (itemsNumber <= 35)
            {
                RectTransform itemSlotRectTransform = Instantiate(itemSlotTemp, itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
                itemSlotRectTransform.gameObject.tag = "clone";
                itemSlotRectTransform.gameObject.name = (itemsNumber).ToString() + "-" + item.ID.ToString();
                itemSlotRectTransform.anchoredPosition = new Vector2(x += shiftX, y + shiftY);
                Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
                image.GetComponent<Image>();
                image.sprite = item.GetSprite();
                line++;
                if (line > 7)
                {
                    line = 1;
                    shiftY -= 45;
                    x = -180;
                }
            }
            itemsNumber++;
        }
    }
    private void EqClose()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
    }
}
