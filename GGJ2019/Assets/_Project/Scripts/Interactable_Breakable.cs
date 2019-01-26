using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Interactable_Breakable : MonoBehaviour, iInteractable
{
    Rigidbody _RB;
    Collider _Collider;
    Transform _OriginalParent;

    PlayerController _InteractingPlayer;

    // Life float

    // Start is called before the first frame update
    void Start()
    {
        _RB = GetComponent<Rigidbody>();
        _Collider = GetComponent<Collider>();
        _OriginalParent = transform.parent;
    }

    #region Interactable interface methods
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void BeginInteraction(PlayerController player)
    {
        _InteractingPlayer = player;
        // Spawn particles for visual feedback

        // Reduce life over time
        // If not life left Tell player that interation is complete
    }

    public void ContinueInteraction(PlayerController player)
    {
        // Reduce life over time
        // If not life left Tell player that interation is complete
    }

    public void EndInteraction(PlayerController player)
    {
       // Stop particles for feedback
    }
    #endregion
}
