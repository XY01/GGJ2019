using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public enum Player
    {
        Player1,
        Player2,
    }
    
    public enum State
    {
        Roaming,
        InteractingEnvironment,
        InteractingEchidna,
        PushingEchidna,
    }

    // States
    public State _State = State.Roaming;
    public Player _Player = Player.Player1;

    public Transform _PickupPosition;

    EchidnaController _Echidna;
    iInteractable _ActiveInteractable;
    List<iInteractable> _InteractablesInRange = new List<iInteractable>();

    // Translation X Z
    Rigidbody _RB;
    Vector3 _Pos;
    public float _Speed = 10;

    
    Vector3 _InputDirection;
    float _InputMagnitude;
    Vector3 InputVector { get { return _InputDirection * _InputMagnitude; } }



    // Height Y
    public float _Radius = .15f;
    float _YOffset = 0;
    
    // Rotation
    float _RotationSmoothing = 8;

    Ray _FwdRay;
    bool _IsMoveBlocked = false;

    // Debug
    public bool _LogInteractables = false;
    public Text _DebugText;

    public bool _Debug_StickyMove = false;
    public bool _Debug_SlipperyMove = false;

    void Start()
    {
        _RB = GetComponent<Rigidbody>();
        _Pos = transform.position;
        _Echidna = FindObjectOfType<EchidnaController>();
    }

    void Update()
    {
        #region movement
        Vector3 newInputVec = Vector3.zero;
        Vector3 newInputDir = Vector3.zero;
        float newInputMag = 0;

        if (_Player == Player.Player1)
        {
            newInputVec.x = Input.GetAxis("HorizontalP1");
            newInputVec.z = Input.GetAxis("VerticalP1");
        }
        else
        {
            newInputVec.x = Input.GetAxis("HorizontalP2");
            newInputVec.z = Input.GetAxis("VerticalP2");
        }

        newInputMag = newInputVec.magnitude;
        newInputDir = newInputVec.normalized;

        // Modulate input vector in case in passive trigger areas      TODO works for now but needs modulation
        if (_Debug_StickyMove)
        {
            // Smooth the input mag
            newInputMag = Mathf.Lerp(_InputMagnitude, newInputMag * .9f, Time.deltaTime * .5f);

            // Set input dir
            newInputDir = Vector3.Lerp(_InputDirection, newInputDir, Time.deltaTime * 10);
        }
        else if (_Debug_SlipperyMove) //TODO 
        {
            // Smooth the input mag
            newInputMag = newInputMag * 2f;// Mathf.Lerp(_InputMagnitude, newInputMag * 2f, Time.deltaTime * 6);

            // Smooth the input dir
            newInputDir = Vector3.Lerp(_InputDirection, newInputDir, Time.deltaTime * 6);
        }

        _InputDirection = newInputDir;// Vector3.Lerp(_InputDirection, newInputDir, Time.deltaTime * 10);
        _InputMagnitude = Mathf.Lerp(_InputMagnitude, newInputMag, Time.deltaTime * 10);

        // Rotation
        if (InputVector != Vector3.zero)
            transform.LookAt(transform.position + InputVector);

        // Raycast forward so we stay on ground. TO DO smooth out later
        RaycastHit hit;
        _FwdRay = new Ray(transform.position, InputVector);
        
        if (Physics.Raycast(_FwdRay, out hit))
            _IsMoveBlocked = hit.collider.gameObject.layer == SRLayers.Terrain && hit.distance < _Radius * 1.5f;

        if (!_IsMoveBlocked)
        {
            // update pos
            _RB.isKinematic = true;
            _Pos += InputVector * Time.deltaTime * _Speed;
            transform.position = _Pos;
        }




        // Raycast down so we stay on ground. TO DO smooth out later        
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
            else if(Input.GetButton("InteractP1") && _ActiveInteractable != null)
                ContinueInteraction();
            else if (Input.GetButtonUp("InteractP1"))
                EndInteraction();
        }
        else
        {
            if (Input.GetButtonDown("InteractP2"))
                TryInteract();
            else if (Input.GetButton("InteractP2") && _ActiveInteractable != null)
                ContinueInteraction();
            else if (Input.GetButtonUp("InteractP2"))
                EndInteraction();
        }
        #endregion

        // if pushing the echidna
        if (_State == State.PushingEchidna) 
        {
            // if echidna isnt being push set state back to roaming
            if (_Echidna.CurrentState != EchidnaController.State.BeingPushed)
                SetState(State.Roaming);
        }

        _DebugText.text = name + " State: " + _State.ToString();
    }

    void SetState(State newState)
    {
        if (newState == State.Roaming)
        {
            _State = newState;
        }
        else if (newState == State.InteractingEnvironment)
        {
            _State = newState;
        }
        else if (newState == State.InteractingEchidna)
        {
            _State = newState;
        }
        else if (newState == State.PushingEchidna)
        {
            _State = newState;
        }
    }


    public void StartStickyZone()
    {
        _InputMagnitude *= .5f;
        _Debug_StickyMove = true;
    }

    public void EndStickyZone()
    {
        _InputMagnitude *= 2;
        _Debug_StickyMove = false;
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

        BeginInteraction(closestInteractable);
    }

    void BeginInteraction(iInteractable interactable)
    {
        print(name + " begun interaction with " + interactable.GetGameObject().name);

        _ActiveInteractable = interactable;
        _ActiveInteractable.BeginInteraction(this);

        if(interactable.GetGameObject().layer == SRLayers.Echidna)
        {
            SetState(State.InteractingEchidna);

            EchidnaController echidna = _ActiveInteractable.GetGameObject().GetComponent<EchidnaController>();
        }
        else if(interactable.GetGameObject().layer == SRLayers.Interactables)
        {
            SetState(State.InteractingEnvironment);
        }        
    }

    void ContinueInteraction()
    {
        _ActiveInteractable.ContinueInteraction(this);
    }

    void EndInteraction()
    {
        if (_ActiveInteractable != null)
        {
            print(name + " ended interaction with " + _ActiveInteractable.GetGameObject().name);
            _ActiveInteractable.EndInteraction(this);
            _ActiveInteractable = null;
        }

        SetState(State.Roaming);
    }

    void FailToInteract()
    {
        // TODO play animation / particles
        print(name + " failed to interact. No interactables in range");
    }

    // Called by interactables once actions are complete
    public void InteractableActionComplete()
    {
        print(_ActiveInteractable.GetGameObject().name + " interaction complete");
        EndInteraction();
    }
    #endregion
    
    #region Triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<iInteractable>() != null)
        {
            if (other.GetComponent<Interactable_Passive>())
            {
                other.GetComponent<Interactable_Passive>().BeginInteraction(this);
            }
            else
            {
                _InteractablesInRange.Add(other.GetComponent<iInteractable>());
            }

            if (_LogInteractables)
                print(other.GetComponent<iInteractable>().GetGameObject().name + " in range");

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<iInteractable>() != null)
        {
            if (other.GetComponent<Interactable_Passive>())
            {
                other.GetComponent<Interactable_Passive>().ContinueInteraction(this);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<iInteractable>() != null)
        {

            if (other.GetComponent<Interactable_Passive>())
            {
                other.GetComponent<Interactable_Passive>().EndInteraction(this);
            }
            else
            {
                _InteractablesInRange.Remove(other.GetComponent<iInteractable>());
            }

            if (_LogInteractables)
                print(other.GetComponent<iInteractable>().GetGameObject().name + " out of range");

            // if the trigger is the echidna and you are pushing
            if (_State == State.PushingEchidna && other.GetComponent<iInteractable>().GetGameObject().GetComponent<EchidnaController>())
                SetState(State.Roaming);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == SRLayers.Echidna)
        {
            collision.gameObject.GetComponent<EchidnaController>().BeginInteraction(this);
            SetState(State.PushingEchidna);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == SRLayers.Echidna)
        {           
            collision.gameObject.GetComponent<EchidnaController>().BeginInteraction(this);
            SetState(State.PushingEchidna);
        }
    }
    #endregion

    #region Debug
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + InputVector);

        Gizmos.color = _IsMoveBlocked ? Color.red : Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + _FwdRay.direction);
    }
    #endregion
}
