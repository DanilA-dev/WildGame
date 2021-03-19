using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinsManager : MonoBehaviour
{
    public static event Action<int> OnValueChanged;  


    private Coin[] coinToCollect;
    public Coin[] CoinToCollect { get => coinToCollect; }

    private int score = 0;



    private void Awake()
    {
        coinToCollect = FindObjectsOfType<Coin>();
    }

    private void OnEnable()
    {
        foreach (var coin in coinToCollect)
        {
            coin.OnCoinPicked += AddCoin;
        }
    }

    private void OnDisable()
    {
        foreach (var coin in coinToCollect)
        {
            coin.OnCoinPicked -= AddCoin;
        }
    }

    private void AddCoin()
    {
        score++;
        OnValueChanged?.Invoke(score);
    }
}
