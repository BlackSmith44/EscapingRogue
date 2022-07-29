using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceScript : MonoBehaviour
{

    public GameObject EnemyPrefab;
    public GameObject ChestPrefab;
    public GameObject PortalPrefab;

    public Transform FloorParent;
    public GameObject Sector0;
    public GameObject Sector1;
    public GameObject Sector2;
    public GameObject Sector3;

    public Sprite Floor1;
    public Sprite Floor2;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEverything();
    }

    // Update is called once per frame
    private void spawnEnemy(GameObject sector)
    {
        GameObject a = Instantiate(EnemyPrefab) as GameObject;
        try
        {
            a.transform.position = new Vector2(sector.transform.position.x + Random.Range(-10, 10), sector.transform.parent.position.y + Random.Range(-10, 10));
            a.name = "Enemy";
            a.SetActive(true);
            a.transform.parent = this.transform.parent;
        }
        catch
        {
            a.transform.position = new Vector2(sector.transform.position.x + Random.Range(-10, 10), sector.transform.parent.position.y + Random.Range(-10, 10));
        }
    }

    private void spawnChest(GameObject sector)
    {
        GameObject a = Instantiate(ChestPrefab) as GameObject;
        a.transform.parent = this.transform.parent;
        a.transform.position = new Vector2(sector.transform.position.x + Random.Range(-5, 5), sector.transform.parent.position.y + Random.Range(-5, 5));
        a.name = "Chest";
        ChestScript chestScript = a.GetComponent<ChestScript>();
        chestScript.num = i;
        i++;
        a.SetActive(true);
    }

    private void CreatePortal()
    {
        Transform tempObj = this.transform.parent.parent;
        Debug.Log(tempObj.name);
        if (tempObj.name == "Room (17)" || tempObj.name == "Room (18)" || tempObj.name == "Room (19)" || tempObj.name == "Room (20)" || tempObj.name == "Room (21)" || tempObj.name == "Room (22)" || tempObj.name == "Room (23)")
        {
            bool gotcha = false;
                foreach(Transform child in GameObject.Find("Room (17)").transform)
                {
                    if (child.name == "Portal")
                    {
                        gotcha = true;
                        break;
                    }
                }
                foreach (Transform child in GameObject.Find("Room (18)").transform)
                {
                    if (child.name == "Portal")
                    {
                        gotcha = true;
                        break;
                    }
                }
                foreach (Transform child in GameObject.Find("Room (19)").transform)
                {
                    if (child.name == "Portal")
                    {
                        gotcha = true;
                        break;
                    }
                }
                foreach (Transform child in GameObject.Find("Room (20)").transform)
                {
                    if (child.name == "Portal")
                    {
                        gotcha = true;
                        break;
                    }
                }
                foreach (Transform child in GameObject.Find("Room (21)").transform)
                {
                    if (child.name == "Portal")
                    {
                        gotcha = true;
                        break;
                    }
                }
                foreach (Transform child in GameObject.Find("Room (22)").transform)
                {
                    if (child.name == "Portal")
                    {
                        gotcha = true;
                        break;
                    }
                }
                foreach (Transform child in GameObject.Find("Room (23)").transform)
                {
                    if (child.name == "Portal")
                    {
                        gotcha = true;
                        break;
                    }
                }
            
            if(!gotcha)
            {
                if (tempObj.name == "Room (20)" || tempObj.name == "Room (21)")
                {
                    GameObject a = Instantiate(PortalPrefab) as GameObject;
                    a.transform.parent = this.transform.parent.parent;
                    a.transform.position = new Vector2(this.transform.parent.position.x, this.transform.parent.position.y);
                    a.name = "Portal";
                }
                else
                {
                    int rand = Random.Range(1, 6);
                    if(rand == 1 || rand == 6)
                    {
                        GameObject a = Instantiate(PortalPrefab) as GameObject;
                        a.transform.parent = this.transform.parent.parent;
                        a.transform.position = new Vector2(this.transform.parent.position.x, this.transform.parent.position.y);
                        a.name = "Portal";
                    }
                }
                
            }

        }  
    }

    private void DamageFloor()
    {
        foreach (Transform child in FloorParent)
        {
            int num = Random.Range(1, 8);
            if(num == 1 || num ==8)
            child.gameObject.GetComponent<SpriteRenderer>().sprite = Floor1;
            else if(num ==2 || num ==7)
            child.gameObject.GetComponent<SpriteRenderer>().sprite = Floor2;

        }
    }

    private void SpawnEverything()
    {
        int rand = Random.Range(4, 8);
        for(int i = 1; i<rand+1; i++)
        {
            int mod = i % 4;
            switch(mod)
            {
                default:
                case 1:
                    {
                        spawnEnemy(Sector1);
                        break; 
                    }
                case 2:
                    {
                        spawnEnemy(Sector2);
                        break;
                    }
                case 3:
                    {
                        spawnEnemy(Sector3);
                        break;
                    }
                case 0:
                    {
                        spawnEnemy(Sector0);
                        break;
                    }
            }
        }
        rand = Random.Range(0, 2);
        if(rand > 0)
        {

            rand = Random.Range(0, 3);
            switch (rand)
            {
                default:
                case 0:
                    {
                        spawnChest(Sector0);
                        break;
                    }
                case 1:
                    {
                        spawnChest(Sector1);
                        break;
                    }
                case 2:
                    {
                        spawnChest(Sector2);
                        break;
                    }
                case 3:
                    {
                        spawnChest(Sector3);
                        break;
                    }
            }
        }
        DamageFloor();
        CreatePortal();
    }
}
