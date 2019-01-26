using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EchidnaController : MonoBehaviour, iInteractable
{
    public float _ControllableRadius = 1.5f;
    public float _PerceptionRadius = 1.5f;

    float _CurrentScale = .4f;
    float _BaseScale = .4f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public bool IsInControllableRange(Vector3 pos)
    {
        return Vector3.Distance(pos, transform.position) < _ControllableRadius;
    }

    public bool IsInPerceptionRange(Vector3 pos)
    {
        return Vector3.Distance(pos, transform.position) < _ControllableRadius;
    }

    #region Interactable interface methods
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void BeginInteraction(PlayerController player)
    {
        // turn rb to is kinematic
        // play pick up particles or animation
    }

    public void ContinueInteraction(PlayerController player)
    {
    }

    public void EndInteraction(PlayerController player)
    {
        // turn rb to isnt kinematic
        // play put down particles or animation
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x * _ControllableRadius);
    }
}
