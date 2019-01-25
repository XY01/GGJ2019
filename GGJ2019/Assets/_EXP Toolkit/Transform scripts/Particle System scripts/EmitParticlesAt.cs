using UnityEngine;
using System.Collections;

namespace EXPToolkit
{
    [RequireComponent(typeof(ParticleSystem))]
    public class EmitParticlesAt : MonoBehaviour
    {
        ParticleSystem m_PSys;

        // Use this for initialization
        void Start()
        {
            m_PSys = GetComponent<ParticleSystem>();

        }

        // Update is called once per frame
        public void EmitAt(int count, Vector3 pos)
        {
            m_PSys.transform.position = pos;
            m_PSys.Emit(count);
        }

        public void EmitAt(int count, Vector3 pos, Color col)
        {
            m_PSys.startColor = col;
            m_PSys.transform.position = pos;
            m_PSys.Emit(count);
        }
    }
}
