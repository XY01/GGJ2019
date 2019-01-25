using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Follows a transform with an offset.
/// Applies to rigid bodies as well as kinematic transforms
/// </summary>
public class FollowOffset : MonoBehaviour
{   
    public enum RotationTarget
    {
        LookAtFollowing,
        LookAtCurrentDirection,
        FollowTransform,
    }

    public Transform _FollowTform;              // Transform to follow  
    Vector3 _CurrentTargetPos;                  // Current target position
    public Vector3 _OffsetDirection = Vector3.up;        // The offset from the transform to follow
    public float _Smoothing = 2;         
    public float _CurrentSpeed = 0;
    public Vector3 _CurrentDirection;
    public RotationTarget _RotationTarget = RotationTarget.LookAtFollowing;
    Rigidbody _RB;

    public bool _SetOffsetFromInitPos = false;


    private void Start()
    {
        if(_SetOffsetFromInitPos)
            _OffsetDirection = _FollowTform.InverseTransformDirection(transform.position - _FollowTform.position);
    }

    public void Init(Transform followT, float smoothing)
    {
        _FollowTform = followT;
        _OffsetDirection = _FollowTform.InverseTransformDirection(transform.position - _FollowTform.position);
        Init( followT,  smoothing, _OffsetDirection);
    }

    public void Init(Transform followT, float smoothing, Vector3 offset)
    {
        _OffsetDirection = offset;
        _FollowTform = followT;
        _Smoothing = smoothing;
        _RB = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        _CurrentTargetPos = _FollowTform.position + _FollowTform.TransformDirection(_OffsetDirection);

        if (_RB != null)
        {
            _RB.AddForce(_CurrentTargetPos-transform.position);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _CurrentTargetPos, Time.deltaTime * _Smoothing);
            _CurrentDirection = _CurrentTargetPos - transform.position;
            _CurrentSpeed = _CurrentDirection.magnitude;

            Quaternion rotation = _FollowTform.rotation;
            if (_RotationTarget == RotationTarget.LookAtFollowing)
            {
                rotation = Quaternion.LookRotation(transform.position - _FollowTform.position, Vector3.up);
            }
            else if (_RotationTarget == RotationTarget.LookAtCurrentDirection)
            {
                rotation = Quaternion.LookRotation(_CurrentDirection, Vector3.up);
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _Smoothing);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_CurrentTargetPos, .06f);
        Gizmos.DrawWireSphere(_FollowTform.TransformPoint( _OffsetDirection), .06f);
    }
}
