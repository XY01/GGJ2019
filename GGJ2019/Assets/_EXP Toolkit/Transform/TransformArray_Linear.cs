using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformArray_Linear : MonoBehaviour
{
    public enum InstantiationType
    {
        SetLength,
        SetCount,
    }

    public enum SpacingType
    {
        World,
        RadiusScaler,
    }

    public GameObject[] _GameObjects;

    public GameObject _PrefabObj;
    public AnimationCurve _RadiusCurve;
    public float _MaxRadius = .5f;

    public InstantiationType _InstantiationType = InstantiationType.SetCount;
    public float _Length = 1;
    public float _Count = 5;

    public float _Spacing = .1f;
    public SpacingType _SpacingType = SpacingType.RadiusScaler;

    public bool _SpawnOnStart = true;
    public Transform _Parent;


    // Start is called before the first frame update
    void Awake()
    {
        if(_SpawnOnStart)
            Spawn();
    }

    // Update is called once per frame
    public void Spawn()
    {
        List<GameObject> gos = new List<GameObject>();
       
        if (_InstantiationType == InstantiationType.SetLength)
        {
            for (int i = 0; i < _Count; i++)
            {
                float norm = i / (float)(_Count - 1);
                Vector3 pos = GetPositionAtNorm(norm);
                float radius = _RadiusCurve.Evaluate(norm) * _MaxRadius;

                GameObject go = Instantiate(_PrefabObj, pos, Quaternion.identity, _Parent);

                go.transform.localScale = radius * 2 * Vector3.one;

                if(i != 0)
                    go.transform.LookAt(gos[i - 1].transform.position);

                gos.Add(go);
            }
        }
        else if (_InstantiationType == InstantiationType.SetCount)
        {
            float dist = _RadiusCurve.Evaluate(0) * _MaxRadius;

            for (int i = 0; i < _Count; i++)
            {
                float norm = i / (float)(_Count - 1);
                float radius = _RadiusCurve.Evaluate(norm) * _MaxRadius;

                if (i != 0)
                {
                    dist += radius;

                    if (_SpacingType == SpacingType.RadiusScaler)
                        dist += _Spacing * radius;
                    else
                        dist += _Spacing;
                }

                Vector3 pos = GetPositionAtLength(dist);

                GameObject go = Instantiate(_PrefabObj, pos, Quaternion.identity, _Parent);
                go.transform.localScale = radius * 2 * Vector3.one;

                dist += radius;

                if (i != 0)
                    go.transform.rotation = Quaternion.LookRotation(go.transform.position - gos[i - 1].transform.position);

                gos.Add(go);
            }
        }

        // Cast list to array
        _GameObjects = gos.ToArray();
    }

    Vector3 GetPositionAtLength(float length)
    {
        Vector3 pos;
        pos = transform.position + (transform.TransformDirection(Vector3.forward) * length);

        return pos;
    }

    Vector3 GetPositionAtNorm(float norm)
    {
        Vector3 pos;
        pos = transform.position + (transform.TransformDirection(Vector3.forward) * (_Length * norm));

        return pos;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (transform.TransformDirection(Vector3.forward) * _Length));

        if (_InstantiationType == InstantiationType.SetLength)
        {
            for (int i = 0; i < _Count; i++)
            {
                float norm = i / (float)(_Count - 1);
                Gizmos.DrawWireSphere(GetPositionAtNorm(norm), _RadiusCurve.Evaluate(norm) * _MaxRadius);
            }
        }
        else if (_InstantiationType == InstantiationType.SetCount)
        {
            float dist = _RadiusCurve.Evaluate(0) * _MaxRadius;

            for (int i = 0; i < _Count; i++)
            {
                float norm = i / (float)(_Count - 1);
                float radius = _RadiusCurve.Evaluate(norm) * _MaxRadius;

                if (i != 0)
                {
                    dist += radius;

                    if (_SpacingType == SpacingType.RadiusScaler)
                        dist += _Spacing * radius;
                    else
                        dist += _Spacing;
                }

                Vector3 pos = GetPositionAtLength(dist);

                Gizmos.DrawWireSphere(pos, radius);

                dist += radius;
            }
        }
    }
}
