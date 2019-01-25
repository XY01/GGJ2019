using UnityEngine;
using System.Collections;

namespace EXPToolkit
{
    /// <summary>
    /// Make a transform look at another transform
    /// 
    /// TODO: Add slerp
    /// </summary>
    [ExecuteInEditMode]
    public class TransformLookAt : MonoBehaviour
    {
        public bool _ExecuteInEditMode = false;
        public Transform m_LookAt;

        void Update()
        {
            if (!Application.isPlaying && _ExecuteInEditMode || Application.isPlaying)
                transform.LookAt(m_LookAt);
        }
    }
}
