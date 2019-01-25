using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class TransformVelocity : MonoBehaviour
{
    public delegate void VelocityEvent();
    public event VelocityEvent OnMaxVelocityReached;
    public event VelocityEvent OnVelocityQuickChange;

    Transform m_Transform;

    // Previous position
    Vector3 m_PrevVelPos;

    // Current velocity
    Vector3 m_RawVel;
    Vector3 m_Vel;
    public Vector3 Vel { get { return m_Vel; } }
    public float Speed { get { return m_Vel.magnitude; } }
    public Vector3 Direction { get { return m_Vel.normalized; } }

    // Smoothing for velocity
    public float m_Smoothing = 12;

    public float m_HighestSpeed;
    float m_MaxSpeedCutoff = 1;

    public float m_SpeedChangeCutoff = 1;
    
    void Awake()
    {
        m_Transform = transform;
    }

    Vector3 changePos;
	public void UpdateVelocity()
    {
        Vector3 prevRawVel = m_RawVel;

        // Calculate velocity
        m_RawVel = (m_Transform.position - m_PrevVelPos) / Time.deltaTime;

        /*
        //float rawSpeedChange = m_RawVel.magnitude - prevRawVel.magnitude;
        //Vector3 rawChangeVel = m_RawVel - prevRawVel;

        if (rawSpeedChange > m_SpeedChangeCutoff )
        {
            changePos = transform.position;
            Debug.DrawLine(m_Transform.position, m_Transform.position + m_RawVel);
        }
        */

        // Velocity smoothing
        m_Vel = Vector3.Lerp(m_Vel, m_RawVel, Time.deltaTime * 8);

        // Store previous pos
        m_PrevVelPos = m_Transform.position;

        // Update max speed
        m_HighestSpeed = Mathf.Max(m_HighestSpeed, Speed);
        m_HighestSpeed -= Time.deltaTime * .1f;
        m_HighestSpeed = Mathf.Max(m_HighestSpeed, 0);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(changePos, .1f);
        Gizmos.DrawSphere(m_Transform.position, .05f );
       // Gizmos.DrawLine(m_Transform.position, m_Transform.position + Vel);
    }
}
