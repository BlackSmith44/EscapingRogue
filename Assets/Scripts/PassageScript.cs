using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageScript : MonoBehaviour
{

    public GameObject RoomOne;
    public GameObject RoomTwo;

    public bool trigged;
    // Start is called before the first frame update
    void Start()
    {
        trigged = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        trigged = true;
        OpenRoom();
    }

    private void OpenRoom()
    {
        if (RoomOne != null)
        {
            if (!RoomOne.activeSelf)
            {
                RoomOne.SetActive(true);
            }
            else RoomOne.SetActive(false);
        }
        if (RoomTwo != null)
        {
            if (!RoomOne.activeSelf)
            {
                RoomTwo.SetActive(true);
            }
            else RoomTwo.SetActive(false);
        }
        
    }
}
