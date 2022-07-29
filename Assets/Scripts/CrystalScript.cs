using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{

    private GameObject Player;
    public GameObject Crystal;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(moveToTarget());
    }

    private IEnumerator moveToTarget()
    {
        Player = GameObject.Find("Player");
        Crystal.transform.position = Vector3.Lerp(Crystal.transform.position, Player.transform.position, Time.deltaTime);
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.gameObject.name == "Player")
        {
            PlayerScript playerScript = collision.transform.gameObject.GetComponent<PlayerScript>();
            playerScript.Score += 1;
            playerScript.player.Exp += 1;
            Destroy(Crystal);
        }
    }
}
