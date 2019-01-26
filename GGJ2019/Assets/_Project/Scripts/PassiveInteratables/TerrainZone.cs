using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainZone : MonoBehaviour, iInteractable
{
    public float _TerrainVelocityScaler = .5f;
    public Vector3 _Force = Vector3.zero;

    #region Interactable interface methods
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void BeginInteraction(PlayerController player)
    {
        player._TerrainVelocityScaler = _TerrainVelocityScaler;
    }

    public void ContinueInteraction(PlayerController player)
    {

    }

    public void EndInteraction(PlayerController player)
    {
        player._TerrainVelocityScaler = 1;
    }

    public float GetNormalizedMass()
    {
        return 1;
    }
    #endregion
}
