using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainZone : Interactable
{
    public float _TerrainVelocityScaler = .5f;
    public Vector3 _LocalizedForce = Vector3.zero;
    public Vector3 WorldSpaceForce { get { return transform.TransformDirection(_LocalizedForce); } }

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
    }

    public float GetNormalizedMass()
    {
        return 1;
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.TransformPoint(_LocalizedForce));
    }
}
