using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class GroundButton : MonoBehaviour
{
    public UnityBoolEvent OnButtonTouchDynamic;
    public UnityEvent OnButtonTouch;
    public UnityEvent OnButtonAway;

    private bool isButtonTouched = false;
    private MeshRenderer mesh;

    private void Awake() => mesh = GetComponent<MeshRenderer>();

    private void Start() => mesh.sharedMaterial.color = Color.red;
    

    private void OnTriggerStay(Collider other)
    {
        InTrigger();
    }

    private void OnTriggerExit(Collider other)
    {
        OffTrigger();
    }

    private void InTrigger()
    {
        isButtonTouched = true;
        OnButtonTouchDynamic?.Invoke(isButtonTouched);
        OnButtonTouch?.Invoke();
        mesh.sharedMaterial.color = Color.green;
    }


    private void OffTrigger()
    {
        isButtonTouched = false;
        OnButtonTouchDynamic?.Invoke(isButtonTouched);
        OnButtonAway?.Invoke();
        mesh.sharedMaterial.color = Color.red;
    }
}
