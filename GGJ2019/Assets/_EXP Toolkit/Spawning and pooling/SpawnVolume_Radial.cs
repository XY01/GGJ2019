using UnityEngine;
using System.Collections;

namespace EXPToolkit
{
    /// <summary>
    /// Radial Volume
    /// - Volumes are used in conjunction with spawners to define spaces in which to spawn objects
    /// </summary>
    public class SpawnVolume_Radial : SpawnVolume
    {
        // The volumes inner radius 
        public float m_InnerRadius = 0;

        // The volumes outer radius 
        public float m_OuterRadius = 0;

        public Color _GizmoCol = Color.blue;

        // Returns a random position in the volume
        public override Vector3 GetRandomLocalPosInVolume()
        {
            Vector3 pos = Random.onUnitSphere;
            pos *= Random.Range(m_InnerRadius, m_OuterRadius);

            return pos;
        }

        // Draw gizmos that define the volume
        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();

            Gizmos.color = _GizmoCol;
            Gizmos.DrawWireSphere(Vector3.zero, m_InnerRadius);
            Gizmos.DrawWireSphere(Vector3.zero, m_OuterRadius);
        }
    }
}
