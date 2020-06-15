using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlacarTracker
{
    public static int Player1Score = 0;
    public static int Player2Score = 0;
    private static int _timesIterated = 0;

    public static bool GameStarted { get; set; } = false;

    public static int TimesIterated => _timesIterated;
    public static void ResetIterated() => _timesIterated = 0;

    public static void AddScore(int player)
    {
        if (player == 1)
            Player1Score++;
        if (player == 2)
            Player2Score++;
    }

    public static string GetPlacar()
    {
        return Player1Score.ToString() + " : " + Player2Score.ToString();
    }

    public static void AddIteration() => _timesIterated++;
}
