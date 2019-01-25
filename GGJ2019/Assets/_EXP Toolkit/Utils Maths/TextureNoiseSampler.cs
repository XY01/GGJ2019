using UnityEngine;
using System.Collections;

namespace EXPToolkit
{
    public class TextureSampler : MonoBehaviour
    {
        private static TextureSampler instance = null;

        public static TextureSampler GetInstance()
        {
            return instance;
        }

        public Texture2D m_NoiseTexture;
        int m_TextureRes;

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            m_TextureRes = m_NoiseTexture.width;
        }

        //float GetNoiseValue( )

        public Vector3 GetNormalizedNoiseAtPosition(Vector3 pos)
        {
            Vector3 movement = Vector3.zero;

            int xPixLookup = (int)((pos.x) * m_TextureRes);
            int yPixLookup = (int)((pos.y) * m_TextureRes);
            int zPixLookup = (int)((pos.z) * m_TextureRes);

            movement.x = m_NoiseTexture.GetPixel(yPixLookup, zPixLookup).r;
            movement.y = m_NoiseTexture.GetPixel(xPixLookup, zPixLookup).g;
            movement.z = m_NoiseTexture.GetPixel(xPixLookup, yPixLookup).b;

            return movement;
        }
    }
}
