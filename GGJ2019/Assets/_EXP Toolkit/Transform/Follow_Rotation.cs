using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Rotation : MonoBehaviour
{
    Transform m_Transform;
    public Transform m_TransformToFollow;
    public float m_Smoothing = 4;

    Quaternion _Rotation;

    public Space m_Space = Space.World;

    void Awake()
    {
        m_Transform = transform;

        if (m_Space == Space.Self)
            _Rotation = m_Transform.localRotation;
        else
            _Rotation = m_Transform.rotation;
    }

    void Update()
    {
        Quaternion targetRot;

        if (m_Space == Space.Self)
            targetRot = m_TransformToFollow.localRotation;
        else
            targetRot = m_TransformToFollow.rotation;

        if (m_Smoothing > 0)
            _Rotation = Quaternion.Slerp(_Rotation, targetRot, m_Smoothing * Time.deltaTime);
        else
            _Rotation = targetRot;

        m_Transform.rotation = _Rotation;
    }
}
