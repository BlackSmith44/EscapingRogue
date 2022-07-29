using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterStatsScript : MonoBehaviour
{
    private GameObject Player;
    public GameObject Crystal;
    private PlayerScript playerScript;
    private TesterScript testerScript;

    public float dmg = 1;
    public float Hp = 5;
    public float CurHp = 1;
    void Start()
    {
        Player = GameObject.Find("Player");
        playerScript = Player.GetComponent<PlayerScript>();
        testerScript = this.gameObject.GetComponent<TesterScript>();
        dmg *= playerScript.CurrLvl;
        Hp *= playerScript.CurrLvl;
        CurHp = Hp;
    }

    void Update()
    {
        if (CurHp <= 0)
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.name == "Player")
        {

            if (testerScript.imHit == false)
            {
                playerScript.GetDmg(dmg);
                testerScript.imHit = true;
            }
            testerScript.zerosVeliocity();
        }
        else
        {
            try
            {
                testerScript.flyaway(this.transform.position, collision.transform.position);
                testerScript.imMoving = true;
            }
            catch
            {

            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.gameObject.name == "Player")
        {
            if (testerScript.imHit == false)
            {
                playerScript.GetDmg(dmg);
                testerScript.imHit = true;
            }
            
            testerScript.zerosVeliocity();
            
            testerScript.rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            try
            {
                testerScript.flyaway(this.transform.position, collision.transform.position);
                testerScript.imMoving = true;
            }
            catch
            {

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.gameObject.name == "Player")
        {
            testerScript.rb.constraints = RigidbodyConstraints2D.None;
            testerScript.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }


    public void GetDmg(float dmg)
    {
        CurHp -= dmg;
        testerScript.imHit = true;
        testerScript.zerosVeliocity();
  
    }

    public void Death()
    {
        int a = Random.Range(2, 5);

        for (int i = 0; i < a; i++)
        {
            SpawnCrystal();
        }

        Destroy(this.gameObject);
    }

    private void SpawnCrystal()
    {
        GameObject a = Instantiate(Crystal) as GameObject;
        a.transform.position = new Vector2(this.gameObject.transform.position.x + Random.Range(-2, 2), this.gameObject.transform.position.y + Random.Range(-2, 2));
        a.SetActive(true);
    }
}
