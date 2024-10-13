using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlight : MonoBehaviour
{
    #region Class References
    Rigidbody rigidBody;

    PlayerUIManager playerUIManager;
    PlayerManager playerManager;
    #endregion

    #region Private Fields
    [Header("Flight Fields")]
    [SerializeField]private float maxFlightTime = 3f;
    [SerializeField] private float flightTimer;
    [SerializeField] private float flightDecayVal = 0.01f;

    [SerializeField] private float flightRegenCooldown = 2f;
    [SerializeField] private float flightRegenTimer;
    [SerializeField] private float flightRegenVal = 0.05f;

    [SerializeField] private float liftForce = 4f;

    [Header("Glide Fields")]
    [SerializeField] private float glideGravity = 4f;    

    #endregion

    #region Properties

    
    #endregion

    #region Start Up
    public void OnAwake()
    {
        playerUIManager = PlayerUIManager.Instance;

        rigidBody = GetComponent<Rigidbody>();
        playerManager = PlayerManager.Instance;
    }
    public void OnStart()
    {
        playerUIManager.HandleSetFlightSlider(maxFlightTime);

    }
    #endregion

    #region Update Functions

    public void OnUpdate(bool glideFlag, bool flightFlag)
    {
        if (flightFlag)
        {
            ApplyFlight();
        }
        else if (!flightFlag && flightTimer != maxFlightTime)
        {
            RegenFlightTimer();
        }
       
        if (glideFlag && rigidBody.velocity.y < 0f)
        {
            ApplyGlideGravity();
        }
    }
    #endregion

    #region Flight Functions
    public void ApplyFlight()
    {
        if (flightTimer <= 0.1f) return;

        rigidBody.useGravity = false;

        Vector3 flightForce = Vector3.up * liftForce;

        rigidBody.AddForce(flightForce, ForceMode.Force);


        flightTimer -= flightDecayVal;
        playerUIManager.HandleUpdateFlightTimer(flightTimer);

        if (flightTimer < 0.1f)
        {
            HandleDisableFlight();
            playerManager.FlightFlag = false;
        }
    }

    private void RegenFlightTimer()
    {
        if (flightRegenTimer != flightRegenCooldown)
        {
            flightRegenTimer += 0.2f;

            if (flightRegenTimer  >= flightRegenCooldown && flightTimer < maxFlightTime)
            {
                //regen flight val
                flightTimer += flightRegenVal;

                playerUIManager.HandleUpdateFlightTimer(flightTimer);
            }
        }
    }
    #endregion

    #region Glide Functions

    public void ApplyGlideGravity()
    {
        rigidBody.useGravity = false;

        Vector3 glideGrav = -Vector3.up * glideGravity;

        rigidBody.AddForce(glideGrav, ForceMode.Force);
    }

    public void HandleDisableFlight()
    {
        rigidBody.useGravity = true;
    }
    public void HandleDisableGlide()
    {
        rigidBody.useGravity = true;
    }
    #endregion

}
