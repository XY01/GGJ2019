using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform _CamLookAtTarget;
    List<Transform> _TransformsToKeepInFocus = new List<Transform>();
    public float _Smoothing = 4;

    Vector3 _BaseOffset;
    Vector3 _AveragePos;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController[] players = FindObjectsOfType<PlayerController>();
        EchidnaController echidna = FindObjectOfType<EchidnaController>();

        _TransformsToKeepInFocus.Add(echidna.transform);
        _TransformsToKeepInFocus.Add(players[0].transform);
        _TransformsToKeepInFocus.Add(players[1].transform);

        UpdateAverage();
        _BaseOffset = transform.position - _AveragePos;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAverage();
        _CamLookAtTarget.position = _AveragePos;// Vector3.Lerp(_CamLookAtTarget.position, _AveragePos, Time.deltaTime * _Smoothing);
        transform.position = _CamLookAtTarget.position + _BaseOffset;
    }

    void UpdateAverage()
    {
        _AveragePos = Vector3.zero;
        for (int i = 0; i < _TransformsToKeepInFocus.Count; i++)
        {
            _AveragePos += _TransformsToKeepInFocus[i].position;
        }
        _AveragePos /= _TransformsToKeepInFocus.Count;
    }
}
