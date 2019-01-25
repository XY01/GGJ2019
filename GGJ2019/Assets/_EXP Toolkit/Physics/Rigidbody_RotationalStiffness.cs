using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Make a rigidbody rotate back towards it's desired rotation
[RequireComponent(typeof(Rigidbody))]
public class Rigidbody_RotationalStiffness : MonoBehaviour
{
    Rigidbody _RB;
    Quaternion _DesiredRotation;
    public float _RotationalForce = 1;

    public Vector3 _WorldLookAt = Vector3.one;

    void Start()
    {
        _RB = GetComponent<Rigidbody>();
    }
   
    void FixedUpdate()
    {
        //get the angle between transform.forward and target delta
        float angleDiff = Vector3.Angle(transform.forward, -_WorldLookAt);

        //float angleDiff = Quaternion.Angle( Quaternion.Euler(transform.forward), _DesiredRotation)

        // get its cross product, which is the axis of rotation to
        // get from one vector to the other
        Vector3 cross = Vector3.Cross(transform.forward, _WorldLookAt);

        // apply torque along that axis according to the magnitude of the angle.
        _RB.AddTorque(cross * angleDiff * _RotationalForce, ForceMode.Acceleration);



        /*
        Vector3 x = Vector3.Cross(oldPoint.normalized, newPoint.normalized);
        float theta = Mathf.Asin(x.magnitude);
        Vector3 w = x.normalized * theta / Time.fixedDeltaTime;
      
Quaternion q = transform.rotation * GetComponent<Rigidbody>().inertiaTensorRotation;
        T = q * Vector3.Scale(GetComponent<Rigidbody>().inertiaTensor, (Quaternion.Inverse(q) * w));
        */
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + _WorldLookAt, .01f);
        Gizmos.DrawLine(transform.position, transform.position + _WorldLookAt);
    }
}
