﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EchidnaController : MonoBehaviour
{
    public float _ControllableRadius = 1.5f;
    public float _PerceptionRadius = 1.5f;

    float _CurrentScale = .4f;
    float _BaseScale = .4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsInControllableRange(Vector3 pos)
    {
        return Vector3.Distance(pos, transform.position) < _ControllableRadius;
    }

    public bool IsInPerceptionRange(Vector3 pos)
    {
        return Vector3.Distance(pos, transform.position) < _ControllableRadius;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x * _ControllableRadius);
    }
}
