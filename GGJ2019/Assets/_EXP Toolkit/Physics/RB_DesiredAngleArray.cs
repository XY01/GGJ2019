using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_DesiredAngleArray : MonoBehaviour
{
    public AnimationCurve _MassScaleCurve;
    public AnimationCurve _StrengthCurve;

    public float _Strength = 0;

    public RB_RotateTowardDesiredAngle[] _DesiredAngleArray;
    Vector3 _BaseScale;
    float _BaseMass;

    // Start is called before the first frame update
    void Awake()
    {
        _BaseScale = _DesiredAngleArray[0].transform.localScale;
        _BaseMass = _DesiredAngleArray[0].GetComponent<Rigidbody>().mass;

        for (int i = 1; i < _DesiredAngleArray.Length; i++)
        {
            float norm = i / (float)(_DesiredAngleArray.Length - 1);
           // _DesiredAngleArray[i].transform.localScale = _BaseScale * _MassScaleCurve.Evaluate(norm);
            _DesiredAngleArray[i].GetComponent<Rigidbody>().mass = _BaseMass * _MassScaleCurve.Evaluate(norm);

            print(norm);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _DesiredAngleArray.Length; i++)
        {
            float norm = i / (float)(_DesiredAngleArray.Length - 1);

            _DesiredAngleArray[i]._ForceScaler = _StrengthCurve.Evaluate(norm) * _Strength;
            _DesiredAngleArray[i]._ForceScaler = _StrengthCurve.Evaluate(norm) * _Strength;
        }
    }
}
