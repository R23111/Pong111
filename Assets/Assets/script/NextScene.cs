using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private void Update()
    {
        if (PlacarTracker.Player1Score == 5 || PlacarTracker.Player2Score == 5)
            SceneManager.LoadScene("GameOver");
    }
}