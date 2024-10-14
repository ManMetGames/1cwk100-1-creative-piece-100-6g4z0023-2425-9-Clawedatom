using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region Class References
    private static CameraManager _instance;
    #endregion

    #region Private Fields
    [Header("Transforms")]
    [SerializeField]private Transform playerTransform;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform pivotTransform;
    



    [Header("Camera Fields")]
    [SerializeField] private float xRotation;
    [SerializeField] private float yRotation;

    [SerializeField] private float mouseSensitivity;

    [SerializeField] private float minPivot = -80f;
    [SerializeField] private float maxPivot = 80f;

    [SerializeField]private float pivotAngle;
    [SerializeField] private float pivotSpeed;

    [SerializeField] private float lookAngle;
    [SerializeField] private float lookSpeed;
     
    #endregion

    #region Properties

    public static CameraManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<CameraManager>();

                if (_instance == null)
                {
                    Debug.LogError("CameraManager has not been assigned");
                    Application.Quit();
                }
            }
            return _instance;

        }
    }
    #endregion

    #region Start Up
    public void OnAwake()
    {

    }
    public void OnStart()
    {

    }
    #endregion

    #region Update Functions

    public void OnUpdate(float mouseX, float mouseY)
    {
        HandleCameraFollow();

        HandleCameraRotation(mouseX, mouseY);
    }
    private void HandleCameraFollow()
    {
        Vector3 targetPosition = playerTransform.position;
        transform.position = targetPosition; 

    }

    private void HandleCameraRotation(float mouseX, float mouseY)
    {
        xRotation += mouseY * mouseSensitivity * Time.deltaTime;
        yRotation += mouseX * mouseSensitivity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, minPivot, maxPivot);

        Vector3 targetRotation;
        


        targetRotation = new Vector3(xRotation, yRotation, 0);
        transform.rotation = Quaternion.Euler(targetRotation);

    }

    
    #endregion
}
