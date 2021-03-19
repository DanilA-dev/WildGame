using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private int loadToLevel;
    private void OnTriggerEnter(Collider other)
    {
        LevelState.LoadLevel(loadToLevel);
    }
}
