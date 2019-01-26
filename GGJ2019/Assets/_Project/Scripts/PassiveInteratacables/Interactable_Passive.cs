﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Passive : MonoBehaviour, iInteractable
{
    PlayerController _InteractingPlayer;

    #region Interactable interface methods
    public virtual GameObject GetGameObject()
    {
        return gameObject;
    }

    public virtual void BeginInteraction(PlayerController player)
    {
        _InteractingPlayer = player;

        print("Begun passive interaction");
    }

    public virtual void ContinueInteraction(PlayerController player)
    {
    }

    public virtual void EndInteraction(PlayerController player)
    {
        print("Ended passive interaction");
    }

    public float GetNormalizedMass()
    {
        return 0;
    }
    #endregion
}
