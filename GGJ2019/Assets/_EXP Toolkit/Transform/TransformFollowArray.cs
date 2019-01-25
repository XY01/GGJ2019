using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TransformArray_Linear))]
public class TransformFollowArray : MonoBehaviour
{
    TransformArray_Linear _FollowArray;  // linear array of transforms

    public float _Smoothing = 12;

    // Start is called before the first frame update
    void Awake()
    {
        _FollowArray = GetComponent<TransformArray_Linear>();

        // Spawn transforms
        _FollowArray.Spawn();

        // Parent first transform the the transform array
        _FollowArray._GameObjects[0].transform.SetParent(_FollowArray.transform);
        _FollowArray._GameObjects[0].transform.localRotation = Quaternion.identity;

        
        for (int i = 1; i < _FollowArray._GameObjects.Length; i++)
        {
            FollowOffset follow = _FollowArray._GameObjects[i].AddComponent<FollowOffset>();
            follow.Init(_FollowArray._GameObjects[i - 1].transform, _Smoothing);         
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
