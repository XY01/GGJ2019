using UnityEngine;
using System.Collections;

namespace EXPToolkit
{
    /// <summary>
    /// Uses a texture sampler to get movement at any given position in space.
    /// Uses R G B channels of the texture to control the direction
    /// Can make use of physics or hard setting of transform
    /// </summary>
    public class TextureMover : MonoBehaviour
    {
        // Texture sampler reference to use
        TextureSampler m_Sampler;

        // Position scaler for texture lookup
        public float m_PosScaler = 1;
        
        public Vector3 m_NormalizedOffsetMagnitude = Vector3.one;
        public float m_OffsetScaler = 1;

        public bool m_UseInitialPos = false;

        // public Texture2D m_XAxisTex;

        public Vector3 m_TextureOffsetSpeed;

        Vector3 m_PosOffset;
        Vector3 m_TargetPos;

        int m_TextureRes;

        Transform m_Transform;

        Vector3 m_InitialPos;

        public bool m_UsePhysics = false;
        public Rigidbody m_RB;

       

        void Start()
        {
            if (m_Transform == null)
                m_Transform = transform;

            m_InitialPos = m_Transform.position;
            m_TargetPos = m_InitialPos;

            m_Sampler = TextureSampler.GetInstance();
            //  m_TextureRes = m_XAxisTex.width;

            m_RB = GetComponent<Rigidbody>();

            m_PosOffset.x = Random.Range(0f, 100f);
            m_PosOffset.y = Random.Range(0f, 100f);
            m_PosOffset.z = Random.Range(0f, 100f);

        }

        void FixedUpdate()
        {
            m_PosOffset += m_TextureOffsetSpeed * Time.deltaTime;

            Vector3 movementVector = Vector3.zero;

            Vector3 inputPos = m_Transform.position;
            if (m_UseInitialPos)
                inputPos = m_InitialPos;

            movementVector = GetMovementVector(inputPos + m_PosOffset);
            movementVector = Vector3.Scale(movementVector, m_NormalizedOffsetMagnitude * m_OffsetScaler);
            m_TargetPos = inputPos + movementVector;          

            if (m_UsePhysics)
                m_RB.AddForce(movementVector, ForceMode.Force);
            else
                transform.position = Vector3.Lerp(transform.position, m_TargetPos, Time.deltaTime * 8);
        }

        Vector3 GetMovementVector(Vector3 pos)
        {
            Vector3 movement = Vector3.zero;

            pos *= m_PosScaler;
            Vector3 textureSample = m_Sampler.GetNormalizedNoiseAtPosition(pos);

            movement.x = -.5f + textureSample.x;
            movement.y = -.5f + textureSample.y;
            movement.z = -.5f + textureSample.z;

            return movement;
        }
    }
}
