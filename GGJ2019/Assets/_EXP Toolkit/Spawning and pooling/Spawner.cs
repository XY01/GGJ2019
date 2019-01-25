using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EXPToolkit
{
    public class Spawner : MonoBehaviour
    {
        public SpawnVolume _SpawnVolume;

        // Array of objects that can be spawned. Randomly chosen from
        [Header("Pooling")]
        public GameObject[] _ObjectsToSpawn;
        public int m_NumberToPool = 30;

        [Header("Spawning")]
        public int _SpawnOnStart = 0;
        public bool _Spawning = false;
        public float _SpawnRate = 0;
        float SpawnInterval { get { return 1f/_SpawnRate; } }

        [Header("Transform initialization")]
        public bool _RandomRotation = false;
        public Vector3 _RotationRange = Vector3.zero;
        public Transform _FacingTransform;
        public bool _RandomScale = false;
        public Vector2 _ScaleRange = Vector3.one;

      

        List<GameObject> m_ActiveObjects = new List<GameObject>();
        List<GameObject> m_InctiveObjects = new List<GameObject>();

        void Start()
        {
            for (int i = 0; i < m_NumberToPool; i++)
            {
                // Instantiate object
                GameObject newGo = Instantiate(_ObjectsToSpawn[Random.Range(0, _ObjectsToSpawn.Length)], Vector3.one * 10000, Quaternion.identity) as GameObject;
                newGo.SetActive(false);
                newGo.transform.SetParent(transform);

                // Add object to the list
                m_InctiveObjects.Add(newGo);
            }

            for (int i = 0; i < _SpawnOnStart; i++)
            {
                Spawn();
            }

            StartCoroutine(SpawnTimer());
        }

        void Update()
        {
            // Remove any inactive items
            m_ActiveObjects.RemoveAll(item => item == null);

            List<GameObject> inactives = new List<GameObject>();
            // Find inactive objects in the active list
            for (int i = 0; i < m_ActiveObjects.Count; i++)
            {
                if (!m_ActiveObjects[i].activeSelf)
                    inactives.Add(m_ActiveObjects[i]);
            }

            // Remove any inactive items
            m_ActiveObjects.RemoveAll(item => !item.activeSelf);

            // Add to inactive list
            for (int i = 0; i < inactives.Count; i++)
            {
                m_InctiveObjects.Add(inactives[i]);
            }

            if (Input.GetKeyDown(KeyCode.A))
                Spawn();
        }

        void Spawn()
        {
            if (m_InctiveObjects.Count == 0)
            {
                print("No inactive objects left to spawn, consider increasing your pooling amount.");
                return;
            }

            // Get Go from incative list
            GameObject newGo = m_InctiveObjects[0];

            // Get position from spawn volume
            Vector3 localPos = _SpawnVolume.GetRandomLocalPosInVolume();
            newGo.transform.localPosition = localPos;// transform.TransformPoint(localPos);

            if (_RandomRotation)
                newGo.transform.rotation = Quaternion.Euler( new Vector3(Random.Range(-_RotationRange.x / 2f, _RotationRange.x / 2f), Random.Range(-_RotationRange.y / 2f, _RotationRange.y / 2f), Random.Range(-_RotationRange.z / 2f, _RotationRange.z / 2f)));

            if (_FacingTransform != null)
                newGo.transform.LookAt(_FacingTransform.position);

            if (_RandomScale)
                newGo.transform.localScale = Vector3.one * Random.Range(_ScaleRange.x, _ScaleRange.y);

            // Remove the object from the inactive list
            m_InctiveObjects.Remove(newGo);

            // set the new object to active
            newGo.SetActive(true);

            // Add Go to active object list
            m_ActiveObjects.Add(newGo);
        }

        IEnumerator SpawnTimer()
        {
            while (true)
            {
                yield return new WaitForSeconds(SpawnInterval);
                if(_Spawning)
                    Spawn();
            }
        }
    }
}
