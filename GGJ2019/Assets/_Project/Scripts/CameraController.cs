using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform _CamLookAtTarget;
    List<Transform> _TransformsToKeepInFocus = new List<Transform>();
    public float _Smoothing = 4;

    public Vector3 _BaseOffset = new Vector3(0, 6, -6);
    Vector3 _AveragePos;

    public bool _Initialised;

    public Vector2 _FovRange = new Vector2(45, 90);
    public Vector2 _DistRange = new Vector2(3, 8);


    void Initialise()
    {
        PlayerController[] players = FindObjectsOfType<PlayerController>();
        EchidnaController echidna = FindObjectOfType<EchidnaController>();

        _TransformsToKeepInFocus.Add(echidna.transform);
        _TransformsToKeepInFocus.Add(players[0].transform);
        _TransformsToKeepInFocus.Add(players[1].transform);

        UpdateAverage();

        _Initialised = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_Initialised)
        {
            print(ExperienceManager.Instance._State);
            if (_TransformsToKeepInFocus.Count != 3)
            {
                Initialise();
            }
            else
            {
                return;
            }
        }

        float normDist = _MaxDist.ScaleTo01(_DistRange.x, _DistRange.y);
        float newFOV = normDist.ScaleFrom01(_FovRange.x, _FovRange.y);
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, newFOV, Time.deltaTime * 1);

        UpdateAverage();
        _CamLookAtTarget.position = _AveragePos;// Vector3.Lerp(_CamLookAtTarget.position, _AveragePos, Time.deltaTime * _Smoothing);
        transform.position = Vector3.Lerp(transform.position, _CamLookAtTarget.position + _BaseOffset, Time.deltaTime * 1);
        transform.LookAt(_CamLookAtTarget.position);
    }

    float _MaxDist = 0;
    void UpdateAverage()
    {
        _MaxDist = 0;
        _AveragePos = Vector3.zero;

        for (int i = 0; i < _TransformsToKeepInFocus.Count; i++)
        {
            _AveragePos += _TransformsToKeepInFocus[i].position;
        }
        _AveragePos /= _TransformsToKeepInFocus.Count;

        for (int i = 0; i < _TransformsToKeepInFocus.Count; i++)
        {
            float dist = Vector3.Distance(_TransformsToKeepInFocus[i].position, _CamLookAtTarget.transform.position);
           if (dist > _MaxDist)
            {
                _MaxDist = dist;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, _AveragePos);

        Gizmos.DrawCube(_AveragePos, Vector3.one * .1f);
        for (int i = 0; i < _TransformsToKeepInFocus.Count; i++)
        {
            Gizmos.DrawLine(_AveragePos, _TransformsToKeepInFocus[i].position);
        }
    }
}
