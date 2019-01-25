using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinRotation : MonoBehaviour
{
    public float m_Speed = 1;

    public Vector3 m_Rotation;

    float m_PerlY;
    float m_PerlX;
    float m_PerlZ;

    Quaternion m_InitialRot;

    public float _Smoothing = 10;

    // Use this for initialization
    void Start ()
    {
        m_InitialRot = transform.localRotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float time = Time.time * m_Speed;
        m_PerlX = (-.5f + Mathf.PerlinNoise(time, time + 5))  * m_Rotation.x;
        m_PerlY = (-.5f + Mathf.PerlinNoise(time + 10, time + 15)) * m_Rotation.y;
        m_PerlZ = (-.5f + Mathf.PerlinNoise(time + 15, time + 20)) * m_Rotation.z;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, m_InitialRot * Quaternion.Euler(m_PerlX, m_PerlY, m_PerlZ), Time.deltaTime * _Smoothing);
    }
}


