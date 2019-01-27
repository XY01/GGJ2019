using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class EchidnaController : Interactable
{
    public enum State
    {
        Idle,
        Wander,
        Seeking,
        BeingPushed,
        Consuming,
    }

    State _State = State.Idle;
    public State CurrentState { get { return _State; } }
    Rigidbody _RB;
  

    float _DrunkenessNorm = 0;  // How much booze he has drank
    float _FullnessNorm = 0;    // How much food he has eaten

    float _MaxSpeed = 4;
    public float _TerrainVelocityScaler = 1;
    float ScaledMaxSpeed { get { return _MaxSpeed * _TerrainVelocityScaler; } }

    // Movement noise
    float _PerlinOffset = 0;
    public float _BasePerlForceScaler = 1;
    public float _BasePerlfieldScaler = 1;
    float _PerlOffset = 0;

    // State vars - Idle
    [Header("State variables")]
    float _StateTimer = 0;
    float _StateTimeoutDuration = 1;
    public float _IdleTimeoutDuration = 3;

    // Pushing
    public float _PushingTimeoutDuration = 2;
    int _PushingCount = 0;

    //Consuming
    public float _ConsumeDuration = 3;

    EchidnaInteractable _ActiveInteractable;
    List<EchidnaInteractable> _InteractablesInRange = new List<EchidnaInteractable>();

    public float _ControllableRadius = 1.5f;
    public float _PerceptionRadius = 1.5f;

    float _CurrentScale = .4f;
    float _BaseScale = .4f;

    [Header("Audio")]
    public AudioClip _Burp;
    public AudioClip _RollStart;
    public AudioClip _RollLoop;
    AudioSource _AudioSource;

    // DEBUG
    public bool _DebugPerlinField = false;

    void Start()
    {
        _RB = GetComponent<Rigidbody>();
        _AudioSource = GetComponent<AudioSource>();
        SetState(State.Idle);
    }

    void Update()
    {
        if (_State == State.Idle)
        {
            // Don't move while idle timer accumulates
            _StateTimer += Time.deltaTime;

            // If idle timeout is up then start to wander
            if (_StateTimer >= _StateTimeoutDuration)
                SetState(State.Wander);
        }
        else if (_State == State.BeingPushed)
        {
            //LimitVelocity();
            //_RB.AddForce(GetPerlinForce(transform.position, _BasePerlfieldScaler, _BasePerlForceScaler, _PerlinOffset));
            

            // Don't move while idle timer accumulates
            _StateTimer += Time.deltaTime;

            // If idle timeout is up then start to wander
            if (_StateTimer >= _StateTimeoutDuration)
                SetState(State.Idle);

        }
        else if (_State == State.Wander)
        {
            // Wander aimlessly until you come across a distraction
            _PerlOffset = Time.time * .1f;
            AddPerlinForce(transform.position, _BasePerlfieldScaler, _BasePerlForceScaler, _PerlOffset);


            // Search for closest interactabl;e
            EchidnaInteractable interactable = SearchForClosestInteractable();
            if (interactable != null)
            {
                _ActiveInteractable = interactable;
                SetState(State.Seeking);
            }
        }
        else if (_State == State.Seeking)
        {
            _RB.AddForce(GetDirectionTowardInteractable());
            // Seek toward target distraction
           
        }
        else if (_State == State.Consuming)
        {
            // Don't move while idle timer accumulates
            _StateTimer += Time.deltaTime;

            // If idle timeout is up then start to wander
            if (_StateTimer >= _StateTimeoutDuration)
            {
                if (_Debug)
                    print(name + " consuming finsihed with timer at: " + _StateTimer + "   " + _StateTimeoutDuration);
                SetState(State.Wander);
            }
        }

        LimitVelocity();

        if (ExperienceManager.Instance != null)
            ExperienceManager.Instance._EchidnaDebug.text = "Echidna - State: " + _State + "  objects in range: " + _InteractablesInRange.Count + "Timer: " + _StateTimer + " / " + _StateTimeoutDuration;
    }

    void SetState(State state)
    {
        if(state == State.Idle)
        {
            _State = state;
            _StateTimer = 0;
            _StateTimeoutDuration = _IdleTimeoutDuration;
        }
        else if (state == State.BeingPushed)
        {
            _State = state;
            _StateTimer = 0;
            _StateTimeoutDuration = _PushingTimeoutDuration;
        }
        else if (state == State.Wander)
        {
            _State = state;
            _StateTimer = 0;

            EchidnaInteractable interactable = SearchForClosestInteractable();
            if (interactable != null)
            {
                _ActiveInteractable = interactable;
                SetState(State.Seeking);
            }
        }
        else if(state == State.Seeking)
        {
            _State = state;
            _StateTimer = 0;

        }
        else if(state == State.Consuming)
        {
            _State = state;
            _StateTimer = 0;
        }

        if(_Debug)
            print(name + " State set to: " + _State.ToString());
    }
    public bool _Debug = false;
    void LimitVelocity()
    {
        if(_RB.velocity.magnitude > ScaledMaxSpeed)
        {
            _RB.velocity = _RB.velocity.normalized * ScaledMaxSpeed;
        }
    }

    Vector3 GetDirectionTowardInteractable()
    {
        return (_ActiveInteractable.transform.position - transform.position);
    }

    EchidnaInteractable SearchForClosestInteractable()
    {
        //print("Searching for interactable: " + _InteractablesInRange.Count);

        EchidnaInteractable interactable = null;

        _InteractablesInRange.RemoveAll(item => item == null);

        if (_InteractablesInRange.Count > 0)
        {
            float closestDist = 999;
            // Look for interactable in range
            foreach (EchidnaInteractable e in _InteractablesInRange)
            {
                float newDist = Vector3.Distance(e.transform.position, transform.position);

                if (newDist < closestDist)
                {
                    closestDist = newDist;
                    interactable = e;
                }
            }
        }

        return interactable;
    }

    // Perlin force and movement
    void AddPerlinForce(Vector3 pos, float perlfieldScaler, float forceScaler, float offset)
    {
        _RB.AddForce(GetPerlinForce(pos, perlfieldScaler, forceScaler, offset));
    }

    Vector3 GetPerlinForce(Vector3 pos, float perlfieldScaler, float forceScaler, float offset)
    {
        Vector3 perlForce = Vector3.zero;
        perlForce.x = Mathf.PerlinNoise((pos.x * perlfieldScaler) + offset, (pos.z * perlfieldScaler) + offset).ScaleFrom01(-1f, 1f);
        perlForce.z = Mathf.PerlinNoise(((pos.x + 1.234f) * perlfieldScaler) + offset, ((pos.z - 2.3454f) * perlfieldScaler) + offset).ScaleFrom01(-1f, 1f);

        return perlForce * forceScaler;
    }   
    
    public bool IsInControllableRange(Vector3 pos)
    {
        return Vector3.Distance(pos, transform.position) < _ControllableRadius;
    }

    public bool IsInPerceptionRange(Vector3 pos)
    {
        return Vector3.Distance(pos, transform.position) < _ControllableRadius;
    }

    void Consume(EchidnaInteractable interactable)
    {
        if (_Debug)
            print(name + "Consumed: " + interactable.name);

        if(interactable._Type == EchidnaInteractable.Type.Food)
        {
            _FullnessNorm += interactable._EffectStrength;           
        }
        else if (interactable._Type == EchidnaInteractable.Type.Booze)
        {
            _DrunkenessNorm += interactable._EffectStrength;
        }

        _ConsumeDuration = interactable.TimeToConsume;
        _ActiveInteractable = null;
        _InteractablesInRange.Remove(interactable);

        Destroy(interactable.gameObject);    

        SetState(State.Consuming);
    }

    #region Interactable interface methods
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public override void BeginInteraction(PlayerController player)
    {
        _PushingCount++;
        SetState(State.BeingPushed);
    }

    public override void EndInteraction(PlayerController player)
    {
        _PushingCount--;

        if (_PushingCount == 0)
            SetState(State.Idle);
    }
    #endregion

    #region Triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EchidnaInteractable>() != null)
        {
            _InteractablesInRange.Add(other.GetComponent<EchidnaInteractable>());
        }
        else if (other.GetComponent<TerrainZone>())
        {
            _RB.velocity = _RB.velocity * .5f;
            _TerrainVelocityScaler = other.GetComponent<TerrainZone>()._TerrainVelocityScaler;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        TerrainZone zone = other.GetComponent<TerrainZone>();
        if (zone != null)
        {
            _RB.AddForce(zone.WorldSpaceForce);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EchidnaInteractable>() != null)
        {
            _InteractablesInRange.Remove(other.GetComponent<EchidnaInteractable>());
        }
        else if (other.GetComponent<TerrainZone>())
        {
            _RB.velocity += _RB.velocity * 2;
            _TerrainVelocityScaler = 1;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EchidnaInteractable>() != null)
        {
            Consume(collision.gameObject.GetComponent<EchidnaInteractable>());
        }
    }
    #endregion

    private void OnDrawGizmos()
    {
        if (_State == State.Seeking)
        {
            Gizmos.DrawLine(transform.position, _ActiveInteractable.transform.position);
        }

        Gizmos.DrawWireSphere(transform.position, transform.localScale.x * _ControllableRadius);

        int pointCount = 10;
        float cellsize = .3f;
       
        Vector3 startPos = transform.position; // - increment * -(pointCount * .5f);
        startPos.x += -(pointCount * .5f) * cellsize;
        startPos.z += -(pointCount * .5f) * cellsize;
        
        if (_DebugPerlinField)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int z = 0; z < 10; z++)
                {
                    Vector3 vecPos = startPos;
                    vecPos.x = startPos.x + (x * cellsize);
                    vecPos.z = startPos.z + (z * cellsize);
                    Debug.DrawLine(vecPos, vecPos + GetPerlinForce(vecPos, _BasePerlfieldScaler, _BasePerlForceScaler, _PerlOffset) * .2f);
                }
            }
        }
    }
}
