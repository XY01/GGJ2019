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

    public enum State
    {
        Roaming,
        InteractingEnvironment,
        InteractingEchidna,
    }

    // States
    public State _State = State.Roaming;
    public Player _Player = Player.Player1;
    public ControlType _ControlType = ControlType.Kinematic;

    public Transform _PickupPosition;

    iInteractable _ActiveInteractable;
    List<iInteractable> _InteractablesInRange = new List<iInteractable>();

    // Translation X Z
    Rigidbody _RB;
    Vector3 _Pos;
    public float _Speed = 10;
    Vector3 _InputVector;

    // Height Y
    public float _Radius = .15f;
    float _YOffset = 0;
    
    // Rotation
    float _RotationSmoothing = 8;


    // Debug
    public bool _LogInteractables = false;

    void Start()
    {
        _RB = GetComponent<Rigidbody>();
        _Pos = transform.position;
    }

    void Update()
    {
        #region movement
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

        //transform.Rotate(Vector3.up * 10);

        if (_InputVector != Vector3.zero)
            transform.LookAt(transform.position + _InputVector);

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(_InputVector), Time.deltaTime * _RotationSmoothing);

        //raycast down so we stay on ground
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = hit.point + (Vector3.up * _Radius);
        }
        #endregion

        #region Interaction
        if (_Player == Player.Player1)
        {
            if(Input.GetButtonDown("InteractP1"))            
                TryInteract();
            else if (Input.GetButtonUp("InteractP1"))
                EndInteraction();
        }
        else
        {
            if (Input.GetButtonDown("InteractP2"))
                TryInteract();
            else if (Input.GetButtonUp("InteractP2"))
                EndInteraction();
        }
        #endregion
    }

    void SetState(State state)
    {
        if (state == State.Roaming)
        {
            _State = state;
        }
        else if (state == State.InteractingEnvironment)
        {
            _State = state;
        }
        else if (state == State.InteractingEchidna)
        {
            _State = state;
        }
    }

    #region Interaction methods
    void TryInteract()
    {
        print(name + " trying to interact. Interactables in range: " + _InteractablesInRange.Count);

        if(_InteractablesInRange.Count == 0)
        {
            FailToInteract();
            return;
        }

        // Find closest interactable
        float closestDist = 999;
        iInteractable closestInteractable = null;
        for (int i = 0; i < _InteractablesInRange.Count; i++)
        {
            float dist = Vector3.Distance(transform.position, _InteractablesInRange[0].GetGameObject().transform.position);

            if(dist < closestDist)
            {
                closestDist = dist;
                closestInteractable = _InteractablesInRange[i];
            }
        }

        BeginInteraction(true, closestInteractable);
    }

    void BeginInteraction(bool beginInteraction, iInteractable interactable)
    {
        if(beginInteraction)
        {
            print(name + " begun interaction with " + interactable.GetGameObject().name);

            _ActiveInteractable = interactable;
            _ActiveInteractable.BeginInteraction(this);

            //if(interactable.GetGameObject().layer)
            {
                SetState(State.InteractingEchidna);
            }
            //else if(interactable.GetGameObject().layer)
            {
                SetState(State.InteractingEnvironment);
            }
        } 
    }

    void EndInteraction()
    {
        if (_ActiveInteractable != null)
        {
            print(name + " ended interaction with " + _ActiveInteractable.GetGameObject().name);
            _ActiveInteractable.StopInteraction(this);
            _ActiveInteractable = null;
        }

        SetState(State.Roaming);
    }

    void FailToInteract()
    {
        // TODO play animation / particles
        print(name + " failed to interact. No interactables in range");
    }
    #endregion


    #region Triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<iInteractable>() != null)
        {
            if (_LogInteractables)
                print(other.GetComponent<iInteractable>().GetGameObject().name + " in range");

            _InteractablesInRange.Add(other.GetComponent<iInteractable>());
            print("Entered echidna trigger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<iInteractable>() != null)
        {
            if (_LogInteractables)
                print(other.GetComponent<iInteractable>().GetGameObject().name + " out of range");

            _InteractablesInRange.Remove(other.GetComponent<iInteractable>());
            print("Exited echidna trigger");
        }
    }
    #endregion

    #region Debug
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + _InputVector);
    }
    #endregion
}
