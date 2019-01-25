using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// - Adds force and torque to a RB at random intervals
/// </summary>

namespace EXPToolkit
{
    [RequireComponent(typeof(Rigidbody))]
    public class RB_MotionPulse : MonoBehaviour
    {
        Rigidbody _RB;

        public ForceMode _ForceMode = ForceMode.Acceleration;
        public Vector2 _IntervalRange = new Vector2(.5f, 1);

        public bool _ApplyVelocity = true;
        public Vector2 _VelocityForceRange = new Vector2(0, 1);

        public bool _ApplyTorque = true;
        public Vector2 _TorqueForceRange = new Vector2(0, 1);


        void Start()
        {
            _RB = GetComponent<Rigidbody>();

            Invoke("BeginPulse", Random.Range(.1f, .5f));
        }

        void BeginPulse()
        {
            StartCoroutine(ApplyForceRoutine());
        }

        void ApplyForce()
        {
            if (_ApplyTorque)
            {
                Vector3 force = _RB.angularVelocity;
                force = force.normalized * Random.Range(_TorqueForceRange.x, _TorqueForceRange.y);
                _RB.AddTorque(force, _ForceMode);
            }

            if (_ApplyVelocity)
            {
                Vector3 force = _RB.velocity;
                force = force.normalized * Random.Range(_VelocityForceRange.x, _VelocityForceRange.y);
                _RB.AddForce(force, _ForceMode);
            }

        }

        IEnumerator ApplyForceRoutine()
        {
            while (true)
            {
                float interval = Random.Range(_IntervalRange.x, _IntervalRange.y);
                yield return new WaitForSeconds(interval);
                ApplyForce();
            }
        }
    }
}
