using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


 public enum PlayerState { Alive, Dead};

public class PlayerController : MonoBehaviour
{
    public PlayerState playerState;


    [SerializeField] private UnityEvent OnPlayerDeath;

    [SerializeField] private Transform playerCamera;

    private PlayerMovement movement;
    private PlayerInput input;

    private Vector3 movementDirection;
    private float turnVelocity = 0f;



    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        switch (playerState)
        {
            case PlayerState.Alive:
                TakeInputInfo();
                PlayerRotation();
                break;
            case PlayerState.Dead:
                PlayerDeath();
                break;
        }

    }

    private void FixedUpdate()
    {
        movement.Move(movementDirection);
        movement.Friction();
    }

    private void TakeInputInfo()
    {
        movementDirection = input.GetInputDirection();
        input.HadleJumpInput(movement);
        input.HandleInteractionInput();
        input.HandlePauseInput();
    }

    private void PlayerRotation()
    {
        if(movementDirection != Vector3.zero)
        {
            if(playerCamera != null)
            {

                float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
                float smoothangle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, movement.SecToRotate);

                transform.rotation = Quaternion.Euler(0, smoothangle, 0);

                movementDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            }
            else
            {
                Debug.Log("MainCam missing on PlayerController?");
            }
        }
    }

    public void PlayerDeath()
    {
        OnPlayerDeath?.Invoke();
        movement.RB.isKinematic = true;
    }


}


