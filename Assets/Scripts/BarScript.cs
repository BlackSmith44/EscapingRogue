using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{

    public Text HpText;
    public Text MpText;
    public Text Lvl;
    public Text Exp;

    public Slider HpBar;
    public Slider MpBar;

    public GameObject Player;

    private float currHp;
    private float currMp;

    void Update()
    {
        PlayerScript playerScript = Player.GetComponent<PlayerScript>();

        HpText.text = playerScript.CurrHP.ToString() + "/" + playerScript.FullHp.ToString();
        MpText.text = playerScript.CurrMP.ToString() + "/" + playerScript.FullMp.ToString();
        Lvl.text = "Lvl: " + playerScript.CurrLvl.ToString();
        Exp.text = "Exp: " + playerScript.CurrExp.ToString() + "/" + playerScript.ExpForNextLvl.ToString();

        currHp = playerScript.CurrHP / playerScript.FullHp;
        currMp = playerScript.CurrMP / playerScript.FullMp;

        HpBar.value = currHp;
        MpBar.value = currMp;
    }



}
