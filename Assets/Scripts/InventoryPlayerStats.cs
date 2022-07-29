using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryPlayerStats : MonoBehaviour
{
    public Text Str;
    public Text Dex;
    public Text Vit;
    public Text Int;
    public Text Lvl;

    public GameObject player;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        PlayerScript playerScript = player.GetComponent<PlayerScript>();
        Str.text = playerScript.tempStr.ToString() + " (+" + playerScript.itemStr.ToString() + ")";
        Dex.text = playerScript.tempDex.ToString() + " (+" + playerScript.itemDex.ToString() + ")";
        Vit.text = playerScript.tempVit.ToString() + " (+" + playerScript.itemVit.ToString() + ")";
        Int.text = playerScript.tempInt.ToString() + " (+" + playerScript.itemInt.ToString() + ")";
        Lvl.text = "(Lvl " + playerScript.CurrLvl.ToString() + ")";
    }
}
