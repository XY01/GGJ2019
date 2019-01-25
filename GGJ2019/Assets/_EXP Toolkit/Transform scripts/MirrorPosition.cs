using UnityEngine;
using System.Collections;

public class MirrorPosition : MonoBehaviour
{
    public Transform m_TransformToMirror;

    public bool m_MirrorX = true;
    public bool m_MirrorY = false;
    public bool m_MirrorZ = false;

    Vector3 m_Position;
    
	// Update is called once per frame
	void Update ()
    {
	    if( m_MirrorX )
        {
            m_Position.x = -m_TransformToMirror.position.x;
        }
        else
        {
            m_Position.x = m_TransformToMirror.position.x;
        }

        if (m_MirrorY)
        {
            m_Position.y = -m_TransformToMirror.position.y;
        }
        else
        {
            m_Position.y = m_TransformToMirror.position.y;
        }

        if (m_MirrorZ)
        {
            m_Position.z = -m_TransformToMirror.position.z;
        }
        else
        {
            m_Position.z = m_TransformToMirror.position.z;
        }

        transform.position = m_Position;
    }
}
