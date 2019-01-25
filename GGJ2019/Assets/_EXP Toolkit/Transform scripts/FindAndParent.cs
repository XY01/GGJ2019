using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAndParent : MonoBehaviour
{
    public string m_ObjectName = "HandRight";
    bool m_Found = false;
    
	void Update ()
    {
        GameObject go = GameObject.Find(m_ObjectName);

        if ( go != null )
        {
            m_Found = true;
            transform.SetParent(go.transform);
            transform.localPosition = Vector3.zero;
            Destroy(this);
        }
	}
}
