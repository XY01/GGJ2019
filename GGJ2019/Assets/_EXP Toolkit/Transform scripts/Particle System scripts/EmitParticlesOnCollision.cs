using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitParticlesOnCollision : MonoBehaviour
{
    public ParticleSystem m_PSys;
    ParticleSystem.EmitParams m_EmitParams;
    Rigidbody m_Rigidbody;

    public float m_OffsetALongNormal = .3f;

    public bool m_ReflectVelocity = false;

    public int m_EmitCount = 3;

    public bool m_Debug = false;

    // Use this for initialization
    void Start()
    {
        m_EmitParams = new ParticleSystem.EmitParams();
        m_Rigidbody = GetComponent<Rigidbody>();
    }    

    void OnCollisionEnter(Collision collision)
    { 
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 pos = contact.point;

            pos += contact.normal * m_OffsetALongNormal;

            m_EmitParams.position = pos;

            if(m_ReflectVelocity)
                m_EmitParams.velocity = Vector3.Reflect(m_Rigidbody.velocity, contact.normal);
            
            m_PSys.Emit(m_EmitParams, m_EmitCount);

            if(m_Debug)
                Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }    
}
