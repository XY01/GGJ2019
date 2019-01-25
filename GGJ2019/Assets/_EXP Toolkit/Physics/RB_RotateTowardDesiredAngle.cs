using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RB_RotateTowardDesiredAngle : MonoBehaviour
{
    Rigidbody _RB;
    Quaternion _DesiredAngle;

    public float _ForceScaler = 4;
    Vector3 _Diff;

    public ForceMode _ForceMode = ForceMode.Acceleration;

    // Start is called before the first frame update
    void Start()
    {
        _RB = GetComponent<Rigidbody>();
        _DesiredAngle = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _Diff = (_DesiredAngle * Quaternion.Inverse(transform.rotation)).eulerAngles;

        if (_Diff.x > 180) _Diff.x = _Diff.x - 360;
        if (_Diff.y > 180) _Diff.y = _Diff.y - 360;
        if (_Diff.z > 180) _Diff.z = _Diff.z - 360;

        // limit min delta to 1 to avoid overshooting
        float delta = Mathf.Min(Time.fixedDeltaTime * _ForceScaler, 1);

        _RB.AddTorque(_Diff * delta, _ForceMode);
    }
}
