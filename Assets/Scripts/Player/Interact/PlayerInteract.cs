using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerInteract : MonoBehaviour
{
    #region Class References

    #endregion

    #region Private Fields
    [SerializeField] private Interactable _currentClosestInteractable;
    
    [SerializeField] private float minDistForInteract = 4f;

    [SerializeField] private float yOffset;

    [SerializeField] private LayerMask interactionLayer;
    #endregion

    #region Properties
    public Interactable CurrentClosestInteractable
    {
        get { return _currentClosestInteractable; }
        set { _currentClosestInteractable = value; }
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

    public void OnUpdate()
    {
        CurrentClosestInteractable = HandleInteractSphere();
    }

    private void OnDrawGizmos()
    {
        Vector3 origin = transform.position;
        origin.y += yOffset;
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(origin, minDistForInteract);
    }

    private Interactable HandleInteractSphere()
    {
        Vector3 origin = transform.position;
        origin.y += yOffset;

        

        RaycastHit hit;

        Collider[] collisions = Physics.OverlapSphere(origin, minDistForInteract, interactionLayer);

        

        if (collisions.Length == 0)  return null;

        GameObject closest = collisions[0].gameObject;
        for (int i = 0; i < collisions.Length - 1; i++)
        {
            Vector3 colPos = collisions[i].transform.position;

            Vector3 dist = colPos - transform.position;

            if (dist.magnitude < (closest.transform.position - transform.position).magnitude)
            {
                closest = collisions[i].gameObject;
            }
        }
        return closest.GetComponent<Interactable>();
        


    }

    public void Interact()
    {
        if (CurrentClosestInteractable != null)
        {
            CurrentClosestInteractable.OnInteract();
        }
    }

    #endregion
}
