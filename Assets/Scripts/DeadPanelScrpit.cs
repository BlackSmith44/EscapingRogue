using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadPanelScrpit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject self;

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            self.SetActive(false);
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }

    }

}
