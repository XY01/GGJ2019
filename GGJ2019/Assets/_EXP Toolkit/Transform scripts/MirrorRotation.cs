using UnityEngine;
using System.Collections;

// mirror XY plane  -z -w
// mirror XZ plane  -z -w
public class MirrorRotation : MonoBehaviour
{
    public Transform m_TargetTransform;

    public Vector4 m_TargetRotation;

    public Vector4 m_ThisRotation;

    public float m_Total;



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_TargetRotation = new Vector4(m_TargetTransform.rotation.x, m_TargetTransform.rotation.y, m_TargetTransform.rotation.z, m_TargetTransform.rotation.w);

        m_Total = m_TargetTransform.rotation.x + m_TargetTransform.rotation.y + m_TargetTransform.rotation.z + m_TargetTransform.rotation.z;

     
         //transform.rotation = Quaternion.Inverse(m_TargetTransform.rotation);
         transform.rotation = Quaternion.Inverse(m_TargetTransform.rotation);
       // transform.rotation = new Quaternion(transform.rotation.z, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        // transform.rotation = new Quaternion(m_ThisRotation.x, m_ThisRotation.y, m_ThisRotation.z, m_ThisRotation.w);
    }
}
