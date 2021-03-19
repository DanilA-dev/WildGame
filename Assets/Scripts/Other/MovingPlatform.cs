using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<GameObject> waypoints = new List<GameObject>();

    private Vector3 target;
    private int wayPointIndex;

    public static event Action OnEnterPlatform;
    public static event Action OnExitPlatform;


    private void Start()
    {
        target = waypoints[0].transform.position;
        wayPointIndex = 0;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target) < 0.1f)
        {
            ChangePoint();
        }
    }

    private void ChangePoint()
    {
        if(wayPointIndex >= waypoints.Count- 1)
        {
          wayPointIndex = 0;
        }
        else
        {
          wayPointIndex++;
        }
        target = waypoints[wayPointIndex].transform.position;
    }


    private void OnCollisionEnter(Collision other)
    {
        other.transform.parent = transform;

        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if(player != null)
        {
            OnEnterPlatform?.Invoke();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        other.transform.parent = null;

        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            OnExitPlatform?.Invoke();
        }
    }



}
