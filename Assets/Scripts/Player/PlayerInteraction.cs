using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable] public class UnityBoolEvent : UnityEvent<bool> { }

[RequireComponent(typeof(PlayerInput))]
public class PlayerInteraction : MonoBehaviour
{
    private bool readyToInteract = false;
    private bool isKeyPressed = false;


    [SerializeField] private Text interactionTextUI;

    [SerializeReference] private PlayerInput input;

    IInteractable interactable;


    private void Awake()
    {
        interactable = GetComponent<IInteractable>();
    }
    private void Update()
    {
        isKeyPressed = input.HandleInteractionInput();
    }

    private void OnTriggerStay(Collider other)
    {
        interactable = other.GetComponent<IInteractable>();

        if (interactable == null)
        {
            return;
        }
        else
        {
            OnInteractionEnter();
            if(isKeyPressed && readyToInteract)
            {
               interactable.InteractWithKey();
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        OnInteractionExit();
    }

    private void OnInteractionEnter()
    {
        if(interactionTextUI != null)
        {
         interactionTextUI.text = interactable.GetDescription();
         readyToInteract = true;
        }
        else
        {
            Debug.Log("InteractionText is missing on PlayerInteractions");
        }
    }

    private void OnInteractionExit()
    {
        if(interactionTextUI != null)
        {
         interactionTextUI.text = null;
         readyToInteract = false;
        }
        else
        {
            Debug.Log("InteractionText is missing on PlayerInteractions");
        }
    }
}
