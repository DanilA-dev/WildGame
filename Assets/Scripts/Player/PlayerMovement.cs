using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    [Header("Forces")]
    [SerializeField] private float acceleration;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity = 5f;

    [Header("GroundCheckers")]
    [SerializeField] private BoxCollider groundCollider;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Body")]
    [SerializeField] private Rigidbody rb;

    [Header("Friction")]
    [SerializeField] private float groundFriction;
    [SerializeField] private float airFriction;

    [Header("Rotation")]
    [Range(0, 1)]
    [SerializeField] private float secToRotate;




    #region PROPERTIES
    public float SecToRotate { get => secToRotate; }

    public bool IsGrounded { get => isGrounded(); }

    public Rigidbody RB { get => rb; set => rb = value; }

    #endregion

    private bool isGrounded()
    {
        if (Physics.CheckBox(groundCollider.bounds.center, groundCollider.bounds.extents, Quaternion.identity, whatIsGround))
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    public  void Move(Vector3 dir)
    {
        dir = dir.normalized;
        rb.AddForce(new Vector3(dir.x * acceleration * Time.deltaTime, rb.velocity.y, dir.z * acceleration * Time.deltaTime),ForceMode.Acceleration);
    }

   public void Friction()
    {
        if (isGrounded() && rb.velocity.magnitude > 0)
        {
            var newDir = rb.velocity * -groundFriction;
            rb.AddForce(newDir * Time.deltaTime);
        }

        if(!isGrounded() && rb.velocity.magnitude > 0)
        {
            var newDir = rb.velocity * -airFriction;
            newDir.y = -gravity;
            rb.AddForce(newDir * Time.deltaTime);
        }
    }

    public  void Jump()
    {
        rb.AddForce(jumpForce * Vector2.up, ForceMode.Impulse);
    }
   
   
}
