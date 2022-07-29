using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour
{
    public Button exitButton;
    void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
