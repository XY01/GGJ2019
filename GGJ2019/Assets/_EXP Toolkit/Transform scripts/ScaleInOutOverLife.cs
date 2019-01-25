using UnityEngine;
using System.Collections;

namespace EXPToolkit
{
    public class ScaleInOutOverLife : MonoBehaviour
    {
        Transform m_Transform;

        // Lifetime variables
        public float m_Lifetime = 10;
        float m_StartTime;
        float EndTime;

        public float m_ScaleDuration = 1;
        Vector3 m_OriginalScale;

        public bool m_AutoInit = false;
        public bool m_ScaleIn = true;

        public bool m_DisaleOnLifeEnd = true;

        // Use this for initialization
        void Awake()
        {
            m_Transform = transform;
            m_StartTime = Time.time;

            if (m_AutoInit)
            {
                Init(transform.localScale.x, m_Lifetime);
            }
        }

        void OnEnable()
        {
            m_StartTime = Time.time;
            EndTime = Time.time + m_Lifetime;
        }

        public void Init(float scale, float lifetime)
        {
            m_OriginalScale = Vector3.one * scale;
            m_Lifetime = lifetime;

            EndTime = Time.time + lifetime;

            if (m_ScaleIn)
                transform.localScale = Vector3.zero;
        }

        bool DisabledPhysics = false;

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Time.time > EndTime - m_ScaleDuration)
            {
                float scale = 1 - (EndTime - Time.time) / m_ScaleDuration;
                m_Transform.localScale = Vector3.Lerp(m_OriginalScale, Vector3.zero, scale);

                if (scale >= 1)
                {
                    if (m_DisaleOnLifeEnd)
                        gameObject.SetActive(false);
                    else
                        Destroy(gameObject);
                }
            }
            else if (Time.time - m_StartTime < m_ScaleDuration && m_ScaleIn)
            {
                float scale = (Time.time - m_StartTime) / m_ScaleDuration;
                m_Transform.localScale = Vector3.Lerp(Vector3.zero, m_OriginalScale, scale);
            }
        }
    }
}
