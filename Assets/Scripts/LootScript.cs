using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Panel;
    public Button TakeButton;
    public Button ExitButton;
    void Start()
    {
        TakeButton.onClick.AddListener(TakeLoot);
        ExitButton.onClick.AddListener(Exit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Exit()
    {
        if(Panel.activeSelf)
        {
            Panel.SetActive(false);
        }
    }
    private void TakeLoot()
    {
        if (Panel.activeSelf)
        {
            Panel.SetActive(false);
        }
    }
}
