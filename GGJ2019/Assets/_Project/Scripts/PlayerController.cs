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
    public enum ControlType
    {
        Keyboard,
        Controller,
    }

    // States
    public State _State = State.Roaming;
    public Player _Player = Player.Player1;
    public ControlType _ControlType = ControlType.Keyboard;

    public Transform _PickupPosition;

    EchidnaController _Echidna;
    Interactable _ActiveInteractable;
    List<Interactable> _InteractablesInRange = new List<Interactable>();

    // Translation X Z
    Rigidbody _RB;
    Vector3 _Pos;
    public float _Speed = 10;

    
    Vector3 _InputDirection;
    float _InputMagnitude;
    public float _InputMagScaler = 1;
    public float _TerrainVelocityScaler = 1;
    Vector3 _ExternalForceVector = Vector3.zero;
    Vector3 FinalMovementVector { get { return (_InputDirection * _InputMagnitude * _InputMagScaler * _TerrainVelocityScaler * _Speed) + (_ExternalForceVector); } }

    GameObject _RaycastHitObject;
    GameObject _LastRaycastHitObject;
    float _RayCastHitDist = 100;

    // Height Y
    public float _Radius = .15f;
    float _YOffset = 0;
    
    // Rotation
    float _RotationSmoothing = 8;

    Ray _FwdRay;
    //bool _IsMoveBlocked = false;

    public LayerMask _ForwardRaycastLayerMask;
    public LayerMask _DownwardRaycastLayerMask;
    public LayerMask _InteractableLayerMask;

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

        gameObject.layer = SRLayers.Players;
    }

    void Update()
    {
        _InteractablesInRange.RemoveAll(item => item == null);

        #region movement
        Vector3 newInputVec = Vector3.zero;
        Vector3 newInputDir = Vector3.zero;
        float newInputMag = 0;
        if (_ControlType == ControlType.Keyboard)
        {
            if (_Player == Player.Player1)
            {
                newInputVec.x = Input.GetAxis("HorizontalP1Keyboard");
                newInputVec.z = Input.GetAxis("VerticalP1Keyboard");
            }
            else
            {
                newInputVec.x = Input.GetAxis("HorizontalP2Keyboard");
                newInputVec.z = Input.GetAxis("VerticalP2Keyboard");
            }
        }
        if (_ControlType == ControlType.Controller)
        {
            if (_Player == Player.Player1)
            {
                newInputVec.x = Input.GetAxis("HorizontalP1Controller");
                newInputVec.z = Input.GetAxis("VerticalP1Controller");
            }
            else
            {
                newInputVec.x = Input.GetAxis("HorizontalP2Controller");
                newInputVec.z = Input.GetAxis("VerticalP2Controller");
            }
        }

        newInputDir = newInputVec.normalized;
        newInputMag = newInputDir.magnitude;
       

        #region Trigger areas
        // Modulate input vector in case in passive trigger areas      TODO works for now but needs modulation
        if (_Debug_StickyMove)
        {
            _TerrainVelocityScaler = .3f;

            /*
            // Smooth the input mag
            newInputMag = Mathf.Lerp(_InputMagnitude, newInputMag * .9f, Time.deltaTime * .5f);

            // Set input dir
            newInputDir = Vector3.Lerp(_InputDirection, newInputDir, Time.deltaTime * 10);
            */
        }
        else if (_Debug_SlipperyMove) //TODO 
        {
            _TerrainVelocityScaler = 2f;

            // Smooth the input mag
            newInputMag = newInputMag * 2f;// Mathf.Lerp(_InputMagnitude, newInputMag * 2f, Time.deltaTime * 6);

            // Smooth the input dir
            newInputDir = Vector3.Lerp(_InputDirection, newInputDir, Time.deltaTime * 6);
        }
        #endregion

        _InputDirection = newInputDir;// Vector3.Lerp(_InputDirection, newInputDir, Time.deltaTime * 10);
        _InputMagnitude = Mathf.Lerp(_InputMagnitude, newInputMag, Time.deltaTime * 10);

        // Rotation
        if (FinalMovementVector != Vector3.zero)
            transform.LookAt(transform.position + FinalMovementVector);

        
        // Raycast forward to see if we are blocked by terrain
        RaycastHit forwardHit;
        _FwdRay = new Ray(transform.position, _InputDirection);

        // Raycast out to find objects that will block movement. Ignore triggers
        if (Physics.Raycast(_FwdRay, out forwardHit, _Radius * 3, _ForwardRaycastLayerMask, QueryTriggerInteraction.Ignore))
        {
            _RaycastHitObject = forwardHit.collider.gameObject;
            _RayCastHitDist = forwardHit.distance;
            
            if (forwardHit.distance < _Radius)
                _InputDirection += forwardHit.normal;
        }
        else
        {
            _RaycastHitObject = null;
        }



        // raycast out to all the local interactables and find if any are slowing down the velociutyt scaler    
        // TO DO dot the forward with the ray to see if it is in front of roughly
        
        bool lowerScalerFound = false;
        foreach (Interactable i in _InteractablesInRange)
        {
            // Raycast forward to see if we are blocked by terrain
            RaycastHit interactableHit;
            Ray rayToInteractable = new Ray(transform.position, i.gameObject.transform.position - transform.position);

            // Raycast out to find objects that will block movement. Ignore triggers
            if (Physics.Raycast(rayToInteractable, out interactableHit, _Radius * 2.5f, _InteractableLayerMask, QueryTriggerInteraction.Ignore))
            {
                if(_Debug)
                    print("Hit : " + interactableHit.collider.name +   "   dist: " + interactableHit.distance);

                if (Vector3.Dot(rayToInteractable.direction, transform.forward) > .3f)
                {
                    lowerScalerFound = true;
                    float newScaler = MassToVelocityScaler( i.gameObject.GetComponent<Rigidbody>().mass );
                    if (newScaler < _InputMagScaler) _InputMagScaler = newScaler;
                    break;
                }
            }
        }

        if (!lowerScalerFound)
            _InputMagScaler = Mathf.Lerp(_InputMagScaler, 1, Time.deltaTime * 8);



        if (_State == State.InteractingEnvironment)
        {
            float interactableInputScaler = MassToVelocityScaler(_ActiveInteractable.gameObject.GetComponent<Rigidbody>().mass);

            if (interactableInputScaler < _InputMagScaler)
                _InputMagScaler = interactableInputScaler;
        }


        // Update pos
        _RB.isKinematic = true;
        _Pos += FinalMovementVector * Time.deltaTime;
        transform.position = _Pos;
        

        // Raycast down so we stay on ground. TO DO smooth out later        
        Ray rayDown = new Ray(transform.position, Vector3.down);        
        if (Physics.Raycast(rayDown, out forwardHit, 10, _ForwardRaycastLayerMask, QueryTriggerInteraction.Ignore))
        {
            transform.position = forwardHit.point + (Vector3.up * _Radius);
        }
        #endregion

        #region Interaction
        if (_ControlType == ControlType.Keyboard)
        {
            if (_Player == Player.Player1)
            {
                if (Input.GetButtonDown("InteractP1Keyboard"))
                    TryInteract();
                else if (Input.GetButton("InteractP1Keyboard") && _ActiveInteractable != null)
                    ContinueInteraction();
                else if (Input.GetButtonUp("InteractP1Keyboard"))
                    EndInteraction();
            }
            else
            {
                if (Input.GetButtonDown("InteractP2Keyboard"))
                    TryInteract();
                else if (Input.GetButton("InteractP2Keyboard") && _ActiveInteractable != null)
                    ContinueInteraction();
                else if (Input.GetButtonUp("InteractP2Keyboard"))
                    EndInteraction();
            }
        }
        if (_ControlType == ControlType.Controller)
        {
            if (_Player == Player.Player1)
            {
                if (Input.GetButtonDown("InteractP1Controller"))
                    TryInteract();
                else if (Input.GetButton("InteractP1Controller") && _ActiveInteractable != null)
                    ContinueInteraction();
                else if (Input.GetButtonUp("InteractP1Controller"))
                    EndInteraction();
            }
            else
            {
                if (Input.GetButtonDown("InteractP2Controller"))
                    TryInteract();
                else if (Input.GetButton("InteractP2Controller") && _ActiveInteractable != null)
                    ContinueInteraction();
                else if (Input.GetButtonUp("InteractP2Controller"))
                    EndInteraction();
            }
        }
        #endregion

        // if pushing the echidna
        if (_State == State.PushingEchidna) 
        {
            // if echidna isnt being push set state back to roaming
            if (_Echidna.CurrentState != EchidnaController.State.BeingPushed)
                SetState(State.Roaming);
        }


        if(ExperienceManager.Instance != null)
            ExperienceManager.Instance._PlayerDebugs[(int)_Player].text = name + " State: " + _State.ToString();
    }

    float MassToVelocityScaler(float mass)
    {
        return Mathf.Clamp01(1 - (mass / 10));
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

        if(_Debug)
            print(name + " state set to : " + _State.ToString());
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
        if (_Debug)
            print(name + " trying to interact. Interactables in range: " + _InteractablesInRange.Count);

        if(_InteractablesInRange.Count == 0)
        {
            FailToInteract();
            return;
        }

        // Find closest interactable
        float closestDist = 999;
        Interactable closestInteractable = null;
        for (int i = 0; i < _InteractablesInRange.Count; i++)
        {
            float dist = Vector3.Distance(transform.position, _InteractablesInRange[0].gameObject.transform.position);

            if(dist < closestDist)
            {
                closestDist = dist;
                closestInteractable = _InteractablesInRange[i];
            }
        }

        BeginInteraction(closestInteractable);
    }

    void BeginInteraction(Interactable interactable)
    {
        if (_Debug)
            print(name + " begun interaction with " + interactable.gameObject.name  + "  from layer " + interactable.gameObject.layer.ToString());
                
        if (interactable.gameObject.layer == SRLayers.Echidna)
        {
            SetState(State.InteractingEchidna);
            EchidnaController echidna = _ActiveInteractable.gameObject.GetComponent<EchidnaController>();
        }
        else if (interactable.gameObject.layer == SRLayers.Interactables)
        {
            SetState(State.InteractingEnvironment);
        }

        _ActiveInteractable = interactable;
        _ActiveInteractable.BeginInteraction(this);
    }

    void ContinueInteraction()
    {
        _ActiveInteractable.ContinueInteraction(this);
    }

    void EndInteraction()
    {
        if (_ActiveInteractable != null)
        {
            if (_Debug)
                print(name + " ended interaction with " + _ActiveInteractable.gameObject.name);
            _ActiveInteractable.EndInteraction(this);
            _ActiveInteractable = null;
        }

        SetState(State.Roaming);
    }

    void FailToInteract()
    {
        // TODO play animation / particles
        if (_Debug)
            print(name + " failed to interact. No interactables in range");
    }

    // Called by interactables once actions are complete
    public void InteractableActionComplete()
    {
        if (_Debug)
            print(_ActiveInteractable.gameObject.name + " interaction complete");

        EndInteraction();
    }
    #endregion

    public bool _Debug = false;
    #region Triggers
    private void OnTriggerEnter(Collider other)
    {
        TerrainZone zone = other.GetComponent<TerrainZone>();
        if (zone != null)
        {
            _TerrainVelocityScaler = zone._TerrainVelocityScaler;
        }
        else if (other.GetComponent<Interactable>() != null)
        {
            _InteractablesInRange.Add(other.GetComponent<Interactable>());            

            if (_LogInteractables)
                print(other.GetComponent<Interactable>().gameObject.name + " in range");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        TerrainZone zone = other.GetComponent<TerrainZone>();
        if (zone != null)
        {
            _ExternalForceVector = zone.WorldSpaceForce;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TerrainZone zone = other.GetComponent<TerrainZone>();
        if (zone != null)
        {
            _ExternalForceVector = Vector3.zero;
            _TerrainVelocityScaler = 1;
        }
        else if (other.GetComponent<Interactable>() != null)
        {            
            _InteractablesInRange.Remove(other.GetComponent<Interactable>());

            if (_LogInteractables)
                print(other.GetComponent<Interactable>().gameObject.name + " out of range");

            // if the trigger is the echidna and you are pushing
            if (_State == State.PushingEchidna && other.GetComponent<Interactable>().gameObject.GetComponent<EchidnaController>())
                SetState(State.Roaming);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        EchidnaController echidna = collision.gameObject.GetComponent<EchidnaController>();
        if (echidna != null)
        {
            echidna.BeginInteraction(this);
            SetState(State.PushingEchidna);
        }
    }
    #endregion

    #region Debug
    private void OnDrawGizmos()
    {
        if (_Debug)
        {
            foreach (Interactable i in _InteractablesInRange)
                Gizmos.DrawWireSphere(i.transform.position, .3f);
        }

        if(_ActiveInteractable != null)
        {
            Gizmos.DrawSphere(_ActiveInteractable.transform.position, .4f);
        }

        Gizmos.DrawLine(transform.position, transform.position + FinalMovementVector);
        Gizmos.DrawWireSphere(transform.position, _Radius * 2);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + _FwdRay.direction);
    }
    #endregion
}
