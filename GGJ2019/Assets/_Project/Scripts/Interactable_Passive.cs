using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Passive : MonoBehaviour, iInteractable
{
    PlayerController _InteractingPlayer;

    #region Interactable interface methods
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void BeginInteraction(PlayerController player)
    {
        _InteractingPlayer = player;

        print("Interaction begun");
    }

    public void ContinueInteraction(PlayerController player)
    {
    }

    public void EndInteraction(PlayerController player)
    {

    }
    #endregion
}
