using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour, IInteractable 
{
    private bool isPressed;
    [SerializeField] private UnityEvent OnInteraction;
    [SerializeField] private string whatIsHint;

    public string GetDescription()
    {
        if (isPressed)
            return null;
        else
            return whatIsHint;
    }

    public void Interact()
    {
       
       
    }

    public void InteractWithKey()
    {
        OnInteraction?.Invoke();
        isPressed = true;
    }
}
