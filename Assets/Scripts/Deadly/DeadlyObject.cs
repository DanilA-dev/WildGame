using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyObject : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if(player == null)
        {
            return;
        }
        else
        {
            player.playerState = PlayerState.Dead;
        }

    }
}
