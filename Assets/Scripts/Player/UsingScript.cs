using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject interactionText;
    private GameObject tempobj;
    public bool trigged;

    void Start()
    {
        interactionText.SetActive(false);
        trigged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f") && trigged)
        {
            if(tempobj.transform.gameObject.name == "Chest")
            {
                ChestScript chestScript = tempobj.GetComponent<ChestScript>();
                chestScript.OpenChest();
            }
            else if (tempobj.transform.gameObject.name == "Portal")
            {
                GameObject Player = GameObject.Find("Player");
                PlayerScript playerScript = Player.GetComponent<PlayerScript>();
                playerScript.PortalExit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {    
        if (collision.transform.gameObject.name == "Chest" || collision.transform.gameObject.name == "Portal")
        {
            tempobj = collision.transform.gameObject;
            interactionText.SetActive(true);
            trigged = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.gameObject.name == "Chest" || collision.transform.gameObject.name == "Portal")
        {
            tempobj = null;
            interactionText.SetActive(false);
            trigged = false;
        }
    }

}
