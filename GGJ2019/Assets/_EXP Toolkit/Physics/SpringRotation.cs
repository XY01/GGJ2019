using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpringRotation : MonoBehaviour
{
    public float force = 10f;

    private new Rigidbody rigidbody;

    public Quaternion _TargetQuaternion;

    private Vector3 torque;

    private void Awake()
    {
        this.rigidbody = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Determine Quaternion 'difference'
        // The conversion to euler demands we check each axis
        /*
        Vector3 torqueF = OrientTorque(Quaternion.FromToRotation(this.transform.forward, this.target.transform.forward).eulerAngles);
        Vector3 torqueR = OrientTorque(Quaternion.FromToRotation(this.transform.right, this.target.transform.right).eulerAngles);
        Vector3 torqueU = OrientTorque(Quaternion.FromToRotation(this.transform.up, this.target.transform.up).eulerAngles);
        */

        Vector3 torqueF = OrientTorque(Quaternion.FromToRotation(this.transform.forward, _TargetQuaternion * Vector3.forward).eulerAngles);
        Vector3 torqueR = OrientTorque(Quaternion.FromToRotation(this.transform.right, _TargetQuaternion * Vector3.right).eulerAngles);
        Vector3 torqueU = OrientTorque(Quaternion.FromToRotation(this.transform.up, _TargetQuaternion * Vector3.up).eulerAngles);

        float magF = torqueF.magnitude;
        float magR = torqueR.magnitude;
        float magU = torqueU.magnitude;

        // Here we pick the axis with the least amount of rotation to use as our torque.
        this.torque = magF < magR ? (magF < magU ? torqueF : torqueU) : (magR < magU ? torqueR : torqueU);

        this.rigidbody.AddTorque(this.torque * Time.fixedDeltaTime * force);
    }

    private Vector3 OrientTorque(Vector3 torque)
    {
        // Quaternion's Euler conversion results in (0-360)
        // For torque, we need -180 to 180.

        return new Vector3
        (
            torque.x > 180f ? 180f - torque.x : torque.x,
            torque.y > 180f ? 180f - torque.y : torque.y,
            torque.z > 180f ? 180f - torque.z : torque.z
        );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (transform.up *.1f));
        Gizmos.DrawLine(transform.position, transform.position + ((_TargetQuaternion * transform.forward)*.1f));
    }
}