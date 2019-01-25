using UnityEngine;
using System.Collections;

namespace EXPToolkit
{
    /// <summary>
    /// Constantly moves and objects by a vector over time
    /// </summary>
    public class ConstantMove : MonoBehaviour
    {
        public Vector3 m_Movement;

        void Update()
        {
            transform.position += m_Movement * Time.deltaTime;
        }
    }
}
