using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Push : MonoBehaviour, iInteractable
{
    #region Interactable interface methods
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void BeginInteraction(PlayerController player)
    {
    }

    public void ContinueInteraction(PlayerController player)
    {
    }

    public void EndInteraction(PlayerController player)
    {
    }
    #endregion
}
