using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTranslation : MonoBehaviour
{
    public float m_Speed = 1;

    public Vector3 m_Translation;

    float m_PerlY;
    float m_PerlX;
	float m_PerlZ;

    Vector3 m_InitialPos;
    

	// Use this for initialization
	void Start ()
    {
        m_InitialPos = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float time = Time.time * m_Speed;
        m_PerlX = ((-.5f + Mathf.PerlinNoise(time, time + 15))  * m_Translation.x);
        m_PerlY = ((-.5f + Mathf.PerlinNoise(time + 20, time + 25)) * m_Translation.y);
		m_PerlZ = ((-.5f + Mathf.PerlinNoise(time + 30, time + 35)) * m_Translation.z);

		transform.localPosition = m_InitialPos + new Vector3(m_PerlX, m_PerlY, m_PerlZ);

    }
}
