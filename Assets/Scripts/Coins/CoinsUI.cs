using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CoinsUI : MonoBehaviour
{
    private TMP_Text coinsCount;
    private CoinsManager coinM;

    private void Awake()
    {
        coinsCount = GetComponent<TMP_Text>();
        coinM = FindObjectOfType<CoinsManager>();
    }


    private void OnEnable()
    {
        CoinsManager.OnValueChanged += CoinsManager_OnValueChanged;
    }

    private void CoinsManager_OnValueChanged(int score)
    {
        coinsCount.text = score + "/" + coinM.CoinToCollect.Length.ToString();
    }
}
