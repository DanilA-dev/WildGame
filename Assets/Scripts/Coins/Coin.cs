using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public event Action OnCoinPicked;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            OnCoinPicked?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
