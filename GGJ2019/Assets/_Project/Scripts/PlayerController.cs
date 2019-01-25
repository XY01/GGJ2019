using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum ControlType
    {
        Physics,
        Kinematic,    
    }

    public ControlType _ControlType = ControlType.Kinematic;

    Rigidbody _RB;

    Vector3 _Pos;
    public float _Speed = 10;
    Vector3 _InputVector;

   

    // Start is called before the first frame update
    void Start()
    {
        _RB = GetComponent<Rigidbody>();

       

        _Pos = transform.position;
    }

    // Update is called once per fram
    void Update()
    {
        _InputVector.x = Input.GetAxis("Horizontal");
        _InputVector.z = Input.GetAxis("Vertical");

        if (_ControlType == ControlType.Kinematic)
        {
            _RB.isKinematic = true;

            _Pos += _InputVector * Time.deltaTime;
            transform.position = _Pos;
        }
        else
        {
            _RB.isKinematic = false;

            _RB.AddForce(_InputVector * _Speed);
        }      
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + _InputVector);
    }
}
