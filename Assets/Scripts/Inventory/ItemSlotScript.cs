using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotScript : MonoBehaviour
{
    public Button button;
    public bool IsSelected;

    void Start()
    {
        button.onClick.AddListener(SelectItem);
        IsSelected = false;
    }

    private void SelectItem()
    {
        ColorBlock colorBlock = button.GetComponent<Button>().colors;
        Color defaultColor = new Color32(87, 13, 13, 225);
        if (!IsSelected)
        {
            colorBlock.selectedColor = Color.white;
            colorBlock.normalColor = Color.white; 
            button.GetComponent<Button>().colors = colorBlock;
            IsSelected = true;
        }
        else
        {
            colorBlock.selectedColor = defaultColor;
            colorBlock.normalColor = defaultColor;
            button.GetComponent<Button>().colors = colorBlock;
            IsSelected = false;
            
        }
    }
}
