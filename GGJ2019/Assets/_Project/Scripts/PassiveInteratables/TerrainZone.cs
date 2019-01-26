using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainZone : Interactable
{
    public float _TerrainVelocityScaler = .5f;
    public Vector3 _Force = Vector3.zero;

    #region Interactable interface methods
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public override void BeginInteraction(PlayerController player)
    {
        player._TerrainVelocityScaler = _TerrainVelocityScaler;
    }

    public override void ContinueInteraction(PlayerController player)
    {

    }

    public override void EndInteraction(PlayerController player)
    {
        player._TerrainVelocityScaler = 1;
    }

    public float GetNormalizedMass()
    {
        return 1;
    }
    #endregion
}
