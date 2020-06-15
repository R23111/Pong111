using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{

    private string[] _scenes =
    {
        "PvP",
        "PvE",
        "About",
        "Exit",
        "GameOver",
        "MainMenu"
    };
    private void Awake()
    {

    }

    public void GoToScene(int scene)
    {
        if(scene == 3)
            Application.Quit();
        else
            SceneManager.LoadScene(_scenes[scene]);
    }

}


/*
 * 0 -> PvP
 * 1 -> PvE
 * 2 -> About
 * 3 -> Exit
 * 4 -> GameOver
 * 5 -> MainMenu
 */