using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KillingScript : MonoBehaviour
{

    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.name == "Enemy")
        {
            Component component = Player.GetComponent("PlayerScript");
            component.SendMessage("Hit", collision);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.gameObject.name == "Enemy")
        {
            Component component = Player.GetComponent("PlayerScript");
            component.SendMessage("Hit", collision);
        }
    }
}
