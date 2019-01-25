using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform _CamLookAtTarget;
    List<Transform> _TransformsToKeepInFocus = new List<Transform>();
    public float _Smoothing = 4;

    // Start is called before the first frame update
    void Start()
    {        
        PlayerController[] players = FindObjectsOfType<PlayerController>();
        EchidnaController echidna = FindObjectOfType<EchidnaController>();

        _TransformsToKeepInFocus.Add(echidna.transform);
        _TransformsToKeepInFocus.Add(players[0].transform);
        _TransformsToKeepInFocus.Add(players[1].transform);        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 average = Vector3.zero;
        for (int i = 0; i < _TransformsToKeepInFocus.Count; i++)
        {
            average += _TransformsToKeepInFocus[i].position;
        }

        average /= _TransformsToKeepInFocus.Count;

        _CamLookAtTarget.position = Vector3.Lerp(_CamLookAtTarget.position, average, Time.deltaTime * _Smoothing);


    }
}
