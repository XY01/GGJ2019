using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TransformArray_Linear))]
[RequireComponent(typeof(LineRenderer))]
public class TransformArray_LineRenderer : MonoBehaviour
{
    TransformArray_Linear _TArray;
    LineRenderer _LineRenderer;


    // Start is called before the first frame update
    void Start()
    {
        _TArray = GetComponent<TransformArray_Linear>();
        _LineRenderer = GetComponent<LineRenderer>();

        _LineRenderer.positionCount = _TArray._GameObjects.Length;

        print("Initialized with count of: " + _LineRenderer.positionCount);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _LineRenderer.positionCount; i++)
        {
            _LineRenderer.SetPosition(i, _TArray._GameObjects[i].transform.position);
        }
    }
}
