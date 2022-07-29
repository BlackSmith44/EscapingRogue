using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootUI : MonoBehaviour
{
    // Start is called before the first frame update

    //private LootInv inventory;

   
    public Transform itemSlotContainer;
    public Transform itemSlotTemp;

    public Button TakeButton;
    public Button ExitButton;

    private ChestScript chestScript;
    private GameObject Self;

    void Start()
    {
        TakeButton.onClick.AddListener(TakeItems);
        ExitButton.onClick.AddListener(ExitPanel);
        Self = this.gameObject;
    }

    public void SetInventory(GameObject chest)
    {
        chestScript = chest.GetComponent<ChestScript>();
        chestScript.OnItemListChanged += Inventory_OnItemListChanged;
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

        int itemsNumber = 1;
        int line = 1;

        int x = -120;
        int y = 25;
        int shiftX = 45;
        int shiftY = 0;
        
        foreach (Item item in chestScript.GetItemList())
        {
            if (itemsNumber <= 8) { 
                RectTransform itemSlotRectTransform = Instantiate(itemSlotTemp, itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
                itemSlotRectTransform.gameObject.tag = "clone";
                itemSlotRectTransform.gameObject.name = (itemsNumber).ToString() + "-" + item.ID.ToString();
                itemSlotRectTransform.anchoredPosition = new Vector2(x += shiftX, y + shiftY);
                Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
                image.sprite = item.GetSprite();
                line++;
                if (line > 4)
                {
                    line = 1;
                    shiftY -= 45;
                    x = -120;

                }
                itemsNumber++;
            }
        }
    }

    private void TakeItems()
    {
        int a = 0;
        int[,] id_tab = new int[8,2];
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemp) continue;
            ItemSlotScript itemSlotScript = child.GetComponent<ItemSlotScript>();
            if (itemSlotScript.IsSelected)
            {
                string[] numbers = child.name.Split('-');
                int b = 0;
                foreach (var number in numbers)
                {
                    
                    id_tab[a, b] = int.Parse(number);
                    b++;
                }
                
                a++;
            }
        }
        chestScript.LootItems(id_tab);
        ExitPanel();
    }

    private void ExitPanel()
    {
        if (Self.activeSelf)
        {
            Self.SetActive(false);
        }
    }


}
