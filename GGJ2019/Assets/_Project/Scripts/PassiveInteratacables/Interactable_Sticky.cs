using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Sticky : Interactable_Passive
{
    #region Interactable interface methods

    public override void BeginInteraction(PlayerController player)
    {
        base.BeginInteraction(player);
        player.StartStickyZone();
    }

    public override void ContinueInteraction(PlayerController player)
    {
        base.ContinueInteraction(player);
    }

    public override void EndInteraction(PlayerController player)
    {
        base.EndInteraction(player);
        player._Debug_StickyMove = false;
    }

    public float GetNormalizedMass()
    {
        return 1;
    }
    #endregion
}
