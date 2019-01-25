using UnityEngine;
using System.Collections;

namespace EXPToolkit
{
    public class FollowTransformPath : MonoBehaviour
    {
        public TransformPath m_Path;

        public float m_BaseSpeed = 1;
        public float m_SpeedScaler = 1;
        public AnimationCurve m_NormSpeedScalOverDistance;

        public float m_Distance = 0;
        public float NormDistance { get { return m_Distance / m_Path._TotalLength; } }

        public float m_LookAhead = 2;

        public bool m_Loop = false;

        public void Update()
        {
            float scaledSpeed = m_BaseSpeed + (m_BaseSpeed * (m_SpeedScaler * m_NormSpeedScalOverDistance.Evaluate(NormDistance)));

            m_Distance += scaledSpeed * Time.deltaTime;

            Vector3 pos = m_Path.GetPosition(m_Distance);

            transform.position = pos;

            if (m_LookAhead > 0 && m_Distance + m_LookAhead < m_Path._TotalLength)
            {
                Vector3 lookPos = m_Path.GetPosition(m_Distance + m_LookAhead);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.position - lookPos), Time.deltaTime * 2);
                //transform.LookAt(lookPos);
            }

            if (m_Loop && m_Distance > m_Path._TotalLength)
            {
                m_Distance -= m_Path._TotalLength;
                transform.rotation = m_Path._PathNodes[0].transform.rotation;
            }
        }
    }
}
