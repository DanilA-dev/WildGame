using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private PlayerController playerController;

    private void Awake() => playerController = GetComponent<PlayerController>();

    private void Update()
    {
        HandleRestartInput();
    }

    public Vector3 GetInputDirection()
    {
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementZ = Input.GetAxisRaw("Vertical");
       var dir = new Vector3(movementX, 0, movementZ);
        return dir;
    }

    public void HadleJumpInput(PlayerMovement movement)
    {
        if (movement.IsGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                movement.Jump();
        }
    }

    public bool HandleInteractionInput()
    {
        if (Input.GetKey(KeyCode.E))
        {
            return true;
        }
        return false;
    }

    public void HandlePauseInput()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GlobalEvents.instance.PauseGame();
            Time.timeScale = 0;
        }
    }

    public void HandleRestartInput()
    {
        if(playerController.playerState == PlayerState.Alive)
        {
            return;
        }
        else
        {
          if (Input.GetKeyDown(KeyCode.R))
          {
              LevelState.ReloadLevel();
          }
        }
    }
}


