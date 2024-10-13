using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    #region Class References
    Rigidbody rigidbody;

    Transform cameraObject;
    #endregion

    #region Private Fields
    [Header("Movement Fields")]
    [SerializeField] private float walkSpeed = 5;
    [SerializeField] private float sprintSpeed = 10;
    [SerializeField] private float _movementSpeed;

    [SerializeField] private Vector3 moveDirection;

    [SerializeField] private float groundDrag = 1f;
    [SerializeField] private float airDrag = 0.4f;

    [Header("Ground Ray Fields")]
    [SerializeField] private float maxRayDist = 0.4f;
    [SerializeField] private float yOffset;
    [SerializeField] private LayerMask ignoreForGroundCheck;


    [Header("Input Fields")]
    [SerializeField] private float jumpForce = 10f;

    #endregion

    #region Properties
    public float MovementSpeed
    {
        get { return _movementSpeed; }
        set { _movementSpeed = value; }
    }

    #endregion

    #region Start Up
    public void OnAwake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public void OnStart()
    {
        cameraObject = Camera.main.transform;   
    }
    #endregion

    #region Update Functions

    public bool OnUpdate(float horizontal, float vertical, bool groundFlag, bool sprintFlag)
    {
        groundFlag = HandleGroundCheck();
        
        HandleMovement(horizontal, vertical, groundFlag, sprintFlag);
        


        return groundFlag;
        
    }

    private bool HandleGroundCheck()
    {
        Vector3 origin = transform.position;
        origin.y += yOffset;

        Debug.DrawRay(origin, -Vector3.up * maxRayDist, Color.red);

        if (Physics.Raycast(origin, -Vector3.up, maxRayDist, ~ignoreForGroundCheck))
        {
            
            return true;
        }
        //moveDirection.y = Physics.gravity.y;
        return false;
    }

    private void HandleMovement(float horizontal, float vertical, bool groundFlag, bool sprintFlag)
    {
        moveDirection = horizontal * cameraObject.forward;
        moveDirection += vertical * cameraObject.right;

        if (groundFlag)
        {
            rigidbody.drag = groundDrag;
            if (sprintFlag)
            {
                MovementSpeed = sprintSpeed;
            }
            else
            {
                MovementSpeed = walkSpeed;
            }
        }
        else
        {
            rigidbody.drag = airDrag;
        }

        moveDirection *= MovementSpeed;
        moveDirection.y = 0f;
        rigidbody.AddForce(moveDirection, ForceMode.Force);

        SpeedControl();
    }

    private void SpeedControl()
    {
        Vector3 vel = rigidbody.velocity;

        if (vel.magnitude > MovementSpeed)
        {
            Vector3 normVel = rigidbody.velocity.normalized;

            Vector3 newVel = normVel * MovementSpeed;

            rigidbody.velocity = new Vector3(newVel.x, rigidbody.velocity.y, newVel.z);
        }
    }
    #endregion


    #region Inputs
    public void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    #endregion
}
