using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Interactable_Breakable : Interactable
{
    PlayerController _InteractingPlayer;

    // Mechanic specific
    public int _HitsToDestroy = 3;
    public GameObject[] _Segments;

    public AudioSource _Source;
    public AudioClip _HitClip;
    public AudioClip _BreakClip;


    private void Start()
    {
        _Source = GetComponent<AudioSource>();
    }

    #region Interactable interface methods   
    public override void BeginInteraction(PlayerController player)
    {
        _InteractingPlayer = player;
        Hit();


    }

    public override void ContinueInteraction(PlayerController player)
    {
        //ReduceHealth();
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
    void Hit()
    {
        if(_HitClip != null)
            _Source.playClip(_HitClip);

        _HitsToDestroy -= 1;

        if (_HitsToDestroy <= 0f)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;

            foreach (GameObject segment in _Segments)
            {
                segment.transform.SetParent(transform.parent);
                segment.SetActive(true);
                segment.GetComponent<Rigidbody>().isKinematic = false;
            }

            _InteractingPlayer.InteractableActionComplete();
        }
    }

}
