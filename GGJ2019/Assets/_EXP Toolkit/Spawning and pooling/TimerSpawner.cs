using UnityEngine;
using System.Collections;

namespace EXPToolkit
{
    public class TimerSpawner : MonoBehaviour
    {
        public GameObject m_ObjectToSpawn;
        public float m_Timer = 3;

        void Start()
        {
            StartCoroutine(SpawnerOnTime());
        }

        IEnumerator SpawnerOnTime()
        {
            while (true)
            {
                GameObject go = Instantiate(m_ObjectToSpawn);
                go.transform.position = transform.position;
                go.transform.rotation = transform.rotation;

                //  go.transform.localScale = Vector3.one * Random.Range(1f, 5.4f);
                go.SetActive(true);
                yield return new WaitForSeconds(m_Timer);
            }
        }
    }
}
