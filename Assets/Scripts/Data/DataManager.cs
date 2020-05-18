using System.Collections;
using System;
using UnityEngine;

public static class DataManager
{
    public static event Action<int> onMoneyChanged;

    public static int Money
    {
        get { return PlayerPrefs.GetInt("player_money", 0); }
        private set { PlayerPrefs.SetInt("player_money", value); }
    }

    public static int BestScore
    {
        get { return PlayerPrefs.GetInt("player_best_score", 0); }
        private set { PlayerPrefs.SetInt("player_best_score", value); }
    }

    public static void EndGame(int money, int distance)
    {
        Money += money;
        SetBestScore(distance);
        onMoneyChanged?.Invoke(money);
    }

    public static void SetBestScore(int score)
    {
        if (score > BestScore)
            BestScore = score;
    }
}
