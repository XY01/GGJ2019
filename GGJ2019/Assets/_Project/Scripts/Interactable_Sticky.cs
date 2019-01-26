using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Sticky : Interactable_Passive, iInteractable
{
    #region Interactable interface methods

    public override void BeginInteraction(PlayerController player)
    {
        print("begun interaction");
    }

    public override void ContinueInteraction(PlayerController player)
    {
    }

    public override void EndInteraction(PlayerController player)
    {

    }
    #endregion
}
