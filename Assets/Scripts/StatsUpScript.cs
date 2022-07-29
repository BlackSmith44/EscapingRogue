using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StatsUpScript : MonoBehaviour
{
    public Button button;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(SkillUP);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScript playerScript = Player.GetComponent<PlayerScript>();

        if (playerScript.SkillPoints > 0)
        {
            button.interactable = true;
        }
        else if(playerScript.SkillPoints >= 0)
        {
            button.interactable = false;
        }
    }



    private void SkillUP()
    {
        PlayerScript playerScript = Player.GetComponent<PlayerScript>();
        switch (button.name)
        {
            default:
            case "STRup":
                {
                    playerScript.player.Str += 1;
                    playerScript.SkillPoints -= 1;
                    break;
                }
            case "VITup":
                {
                    playerScript.player.Vit += 1;
                    playerScript.SkillPoints -= 1;
                    break;
                }
            case "DEXup":
                {
                    playerScript.player.Dex += 1;
                    playerScript.SkillPoints -= 1;
                    break;
                }
            case "INTup":
                {
                    playerScript.player.Int += 1;
                    playerScript.SkillPoints -= 1;
                    break;
                }
        }
    }
}
