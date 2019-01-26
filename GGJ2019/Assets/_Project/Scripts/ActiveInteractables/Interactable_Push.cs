using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Push : Interactable
{
    #region Interactable interface methods
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public override void BeginInteraction(PlayerController player)
    {
    }

    public override void ContinueInteraction(PlayerController player)
    {
    }

    public override void EndInteraction(PlayerController player)
    {
    }
    #endregion
}
