using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Interactable_PickAndPlace : Interactable
{
    Rigidbody _RB;
    Collider _Collider;
    Transform _OriginalParent;

    public float _NormalizedMass = .8f;

    // Start is called before the first frame update
    void Start()
    {
        _RB = GetComponent<Rigidbody>();
        _Collider = GetComponent<Collider>();
        _OriginalParent = transform.parent;
    }

    #region Interactable interface methods  
    public override void BeginInteraction(PlayerController player)
    {
        transform.SetParent(player._PickupPosition);
        transform.localPosition = Vector3.zero;

        gameObject.layer = SRLayers.PickedUpInteractable;

        _RB.isKinematic = true;

        // turn rb to is kinematic
        // play pick up particles or animation
    }

    public override void EndInteraction(PlayerController player)
    {
        transform.SetParent(_OriginalParent);
        _RB.isKinematic = false;

        gameObject.layer = SRLayers.Interactables;

        // turn rb to isnt kinematic
        // play put down particles or animation
    }
    #endregion
}
