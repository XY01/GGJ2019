using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EXP Toolkit - RB Add Force Toward
///  - Adds a force toward a target transform
///  - Can run every update or run at random intervals to give a pulsing effect
/// </summary>
namespace EXPToolkit
{
    [RequireComponent(typeof(Rigidbody))]
    public class RB_AddForceTowardTarget : MonoBehaviour
    {
        public enum ApplicationMode
        {
            FixedUpdate,
            Intervals,
        }

        Rigidbody _RB;
        public Transform _Target;
        public float _ForceStrength = 1;
        public ForceMode _ForceMode = ForceMode.Acceleration;

        // How is this applied, every frame or at intervals
        public ApplicationMode _ApplicationMode = ApplicationMode.FixedUpdate;
        public Vector2 _IntervalRange = new Vector2(.5f, 1);
        Transform _T;

        // Should it rotate to face the target
        public bool _RotateToFaceTarget = false;
        public float _LookAtForce = 10;

        void Start()
        {
            _RB = GetComponent<Rigidbody>();
            _T = transform;

            if (_ApplicationMode == ApplicationMode.Intervals)
                StartCoroutine(ApplyForceRoutine());
        }

        void FixedUpdate()
        {
            if (_ApplicationMode == ApplicationMode.FixedUpdate)
                ApplyForce(Time.fixedDeltaTime);

            if (_RotateToFaceTarget)
            {
                _RB.MoveRotation(Quaternion.Slerp(_T.rotation, Quaternion.LookRotation(_RB.velocity), Time.fixedDeltaTime * _LookAtForce));
            }
        }

        void ApplyForce(float delta)
        {
            Vector3 force = _Target.position - _T.position;
            force = force.normalized * _ForceStrength;
            _RB.AddForce(force * delta, _ForceMode);
        }

        IEnumerator ApplyForceRoutine()
        {
            while (true)
            {
                float interval = Random.Range(_IntervalRange.x, _IntervalRange.y);
                yield return new WaitForSeconds(interval);
                ApplyForce(1);
            }
        }
    }
}
