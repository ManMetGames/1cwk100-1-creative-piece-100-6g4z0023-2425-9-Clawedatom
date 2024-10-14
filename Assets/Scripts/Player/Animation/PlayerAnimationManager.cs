using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    #region Class References
    Animator animator;
    #endregion

    #region Private Fields
    private int vertical;
    private int horizontal;
    #endregion

    #region Properties

    
    #endregion

    #region Start Up
    public void OnAwake()
    {
        animator = GetComponent<Animator>();

        vertical = Animator.StringToHash("Vertical");
        horizontal = Animator.StringToHash("Horizontal");
    }
    public void OnStart()
    {

    }
    #endregion

    #region Update Functions

    public void OnUpdate(float h, float v, bool g, bool s, bool f)
    {
        CalculateAnimatorValues(h, v, g, s, f);
    }


    private void CalculateAnimatorValues(float horizontalMovement, float verticalMovement, bool isGrounded, bool isSprinting, bool isFlying)
    {
        float h;
        float v;

        if (horizontalMovement > 0.5f)
        {
            h = 1f;
        }
        else
        {
            h = 0f;
        }


        if (isGrounded)
        {
            if (isSprinting)
            {
                h = 2f;
            }
        }
        else 
        {
            h = -2f;
        }

        if (isFlying)
        {
            h = 0f;
        }
        
        animator.SetFloat(horizontal, h, 0.2f, Time.deltaTime);
    }
    #endregion
}
