using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Example of Poisson disc distribution where you give it an object of x radius and it makes sure
/// they are randomly distributed but never overlap
/// </summary>

public class PoissonDiscSampler_Example : MonoBehaviour
{
    public GameObject _Prefab;

    public Vector2 _Dimensions = new Vector2(1, 1);
    public float _Radius = .1f;
    public float _ScaleMultiplyer = 1;

    PoissonDiscSampler _Sampler;

    List<GameObject> _SpawnedObjects = new List<GameObject>();

    [Range(0,1)]
    public float _PercentageToSpawn = 1;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Generate();
    }

    // Update is called once per frame
    void Generate()
    {
        // Destroy all existing obejcts
        foreach (GameObject go in _SpawnedObjects)
            Destroy(go);

        // Clear spawned list
        _SpawnedObjects.Clear();

        _Sampler = new PoissonDiscSampler(_Dimensions.x, _Dimensions.y, _Radius);
        Vector3 startPos = new Vector3(-_Dimensions.x * .5f, 0, -_Dimensions.y * .5f);

        foreach (Vector2 sample in _Sampler.Samples())
        {
            float rand = Random.Range(0f, 1f);

            if(rand < _PercentageToSpawn)
            {
                GameObject go = Instantiate(_Prefab, new Vector3(startPos.x + sample.x, 0f, startPos.z + sample.y), Quaternion.identity);
                go.transform.SetParent(transform);
                go.transform.localScale = Vector3.one * _Radius * _ScaleMultiplyer;

                _SpawnedObjects.Add(go);
            }
        }
    }
}
