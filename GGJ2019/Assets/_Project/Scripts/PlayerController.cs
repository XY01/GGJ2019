using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Player
    {
        Player1,
        Player2,
    }

    public enum ControlType
    {
        Physics,
        Kinematic,    
    }

    public Player _Player = Player.Player1;
    public ControlType _ControlType = ControlType.Kinematic;

    Rigidbody _RB;

    Vector3 _Pos;
    public float _Speed = 10;
    Vector3 _InputVector;
    public float _Radius = .15f;

    float _YOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        _RB = GetComponent<Rigidbody>();
        _Pos = transform.position;
    }

    // Update is called once per fram
    void Update()
    {
        if (_Player == Player.Player1)
        {
            _InputVector.x = Input.GetAxis("HorizontalP1");
            _InputVector.z = Input.GetAxis("VerticalP1");
        }
        else
        {
            _InputVector.x = Input.GetAxis("HorizontalP2");
            _InputVector.z = Input.GetAxis("VerticalP2");
        }

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

        //raycast down so we stay on ground
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = hit.point + (Vector3.up * _Radius);
        }
    }

    void Interact()
    {

    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<iInteractable>() != null)
        {
            print("Entered echidna trigger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<iInteractable>() != null)
        {
            print("Exited echidna trigger");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + _InputVector);
    }
}
