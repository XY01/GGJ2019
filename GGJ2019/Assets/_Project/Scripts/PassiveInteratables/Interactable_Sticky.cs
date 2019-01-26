using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Sticky : Interactable_Passive, iInteractable
{
    #region Interactable interface methods

    public override void BeginInteraction(PlayerController player)
    {
        base.BeginInteraction(player);
        print("begun interaction");
    }

    public override void ContinueInteraction(PlayerController player)
    {
        base.ContinueInteraction(player);

    }

    public override void EndInteraction(PlayerController player)
    {
        base.EndInteraction(player);


    }

    public float GetNormalizedMass()
    {
        return 1;
    }
    #endregion
}
