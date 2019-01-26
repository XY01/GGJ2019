using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainZone : MonoBehaviour
{
    public float _TerrainVelocityScaler = .5f;
    public Vector3 _LocalizedForce = Vector3.zero;
    public Vector3 WorldSpaceForce { get { return transform.TransformDirection(_LocalizedForce); } }
    
    public void BeginInteraction(PlayerController player)
    {
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.TransformPoint(_LocalizedForce));
    }
}
