using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Interactable_Breakable : Interactable
{
    bool _IsDestroyed = false;
    PlayerController _InteractingPlayer;

    // Mechanic specific
    public float _Health;
    public float _InteractionStrength;
    public GameObject[] _Segments;

    #region Interactable interface methods   
    public override void BeginInteraction(PlayerController player)
    {
        _InteractingPlayer = player;
        ReduceHealth();
    }

    public override void ContinueInteraction(PlayerController player)
    {
        ReduceHealth();
    }

    public override void EndInteraction(PlayerController player)
    {

    }

    public float GetNormalizedMass()
    {
        return 0;
    }
    #endregion


    // Reduce life over time
    // If no life left tell player that interation is complete
    void ReduceHealth()
    {
        _Health -= _InteractionStrength;
        print(_Health);

        if (_Health <= 0f)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;

            foreach (GameObject segment in _Segments)
            {
                segment.SetActive(true);
                segment.GetComponent<Rigidbody>().isKinematic = false;
            }
            _InteractingPlayer.InteractableActionComplete();
        }
    }

}
