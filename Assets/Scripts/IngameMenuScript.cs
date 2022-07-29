using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IngameMenuScript : MonoBehaviour
{

    public Button ResumeButton;
    public Button ExitButton;

    public GameObject self;
    void Start()
    {
        ResumeButton.onClick.AddListener(Resume);
        ExitButton.onClick.AddListener(Exit);
    }

    void Resume()
    {
        self.SetActive(false);
    }

    void Exit()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
