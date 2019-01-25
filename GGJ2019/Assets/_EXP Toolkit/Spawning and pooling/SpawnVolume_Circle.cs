using UnityEngine;
using System.Collections;

namespace EXPToolkit
{
    /// <summary>
    /// Radial Volume
    /// - Volumes are used in conjunction with spawners to define spaces in which to spawn objects
    /// </summary>
    public class SpawnVolume_Circle : SpawnVolume
    {
        // The volumes inner radius 
        public float m_InnerRadius = 0;

        // The volumes outer radius 
        public float m_OuterRadius = 0;

        public Color _GizmoCol = Color.blue;

        // Returns a random position in the volume
        public override Vector3 GetRandomLocalPosInVolume()
        {
            Vector2 pos = Random.insideUnitCircle.normalized;
            pos *= Random.Range(m_InnerRadius * .5f, m_OuterRadius * .5f);            

            return new Vector3(pos.x, 0, pos.y);
        }

        // Draw gizmos that define the volume
        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();

            Gizmos.color = _GizmoCol;

            float norm = 0;
            int numSides = 18;

            Vector3 innerPos = Vector3.one;
            Vector3 outerPos = Vector3.one;
            for (int i = 0; i < numSides; i++)
            {
                norm = (float)i / (float)(numSides-1);
                float x = Mathf.Sin(norm * 360 * Mathf.Deg2Rad);
                float z = Mathf.Cos(norm * 360 * Mathf.Deg2Rad);

                Vector3 newInnerPos = new Vector3(x * m_InnerRadius * .5f, 0, z * m_InnerRadius * .5f);
                Vector3 newOuterPos = new Vector3(x * m_OuterRadius * .5f, 0, z * m_OuterRadius * .5f);

                if (i > 0)
                {
                    Gizmos.DrawLine(newInnerPos, innerPos);
                    Gizmos.DrawLine(newOuterPos, outerPos );
                }

                innerPos = newInnerPos;
                outerPos = newOuterPos;
            }
        }
    }
}
