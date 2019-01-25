using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform_RotationScaler : MonoBehaviour
{
    public Transform _TargetTransform;
    Transform _T;
    public Vector3 _AxisOffsets = Vector3.zero;
    Quaternion _AxisOffsetQuaternion;
    public Space _Space = Space.Self;  
    public float _Smoothing = 0;


    private void Start()
    {
        _T = transform;
    }

    void Update()
    {
        if(_Space == Space.Self)
            _AxisOffsetQuaternion = Quaternion.Euler(_AxisOffsets.ScaleReturn(_TargetTransform.localRotation.eulerAngles));
        else
            _AxisOffsetQuaternion = Quaternion.Euler(_AxisOffsets.ScaleReturn(_TargetTransform.rotation.eulerAngles));

        if (_Smoothing > 0)
            _T.rotation = Quaternion.Slerp(_T.rotation, _TargetTransform.rotation * _AxisOffsetQuaternion, Time.deltaTime * _Smoothing);
        else
            _T.rotation = _TargetTransform.rotation * _AxisOffsetQuaternion;
    }
}
