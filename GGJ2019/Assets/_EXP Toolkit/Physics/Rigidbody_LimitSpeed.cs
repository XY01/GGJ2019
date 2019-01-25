using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rigidbody_LimitSpeed : MonoBehaviour
{
    Rigidbody _RB;
    public float _MaxSpeed = 10;
    float _SqrMaxSpeed;

    private void Start()
    {
        _RB = GetComponent<Rigidbody>();
        _SqrMaxSpeed = _MaxSpeed * _MaxSpeed;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_RB.velocity.sqrMagnitude > _SqrMaxSpeed)
            _RB.velocity = _RB.velocity.normalized * _MaxSpeed;
    }
}
