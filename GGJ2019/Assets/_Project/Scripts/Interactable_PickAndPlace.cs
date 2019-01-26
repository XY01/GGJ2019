using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Interactable_PickAndPlace : MonoBehaviour, iInteractable
{
    Rigidbody _RB;

    Transform _OriginalParent;

    // Start is called before the first frame update
    void Start()
    {
        _RB = GetComponent<Rigidbody>();
        _OriginalParent = transform.parent;
    }

    #region Interactable interface methods
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void BeginInteraction(PlayerController player)
    {
        transform.SetParent(player._PickupPosition);
        transform.localPosition = Vector3.zero;

        _RB.isKinematic = true;
        
        // turn rb to is kinematic
        // play pick up particles or animation
    }

    public void StopInteraction(PlayerController player)
    {
        transform.SetParent(_OriginalParent);
        transform.localPosition = Vector3.zero;

        _RB.isKinematic = false;

        // turn rb to isnt kinematic
        // play put down particles or animation
    }
    #endregion
}
