using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class EchidnaController : MonoBehaviour, iInteractable
{
    public enum State
    {
        Idle,
        Wander,
        Seeking,
        BeingPushed,
    }

    State _State = State.Idle;
    public State CurrentState { get { return _State; } }
    Rigidbody _RB;

  

    float _DrunkenessNorm = 0;  // How much booze he has drank
    float _FullnessNorm = 0;    // How much food he has eaten

    // Movement noise
    float _PerlinOffset = 0;
    public float _BasePerlForceScaler = 1;
    public float _BasePerlfieldScaler = 1;
    float _PerlOffset = 0;


    // State vars - Idle
    [Header("State variables")]
    float _StateTimer = 0;
    public float _IdleTimeoutDuration = 3;

    // Pushing
    public float _PushingTimeoutDuration = 2;
    int _PushingCount = 0;


    public float _ControllableRadius = 1.5f;
    public float _PerceptionRadius = 1.5f;

    float _CurrentScale = .4f;
    float _BaseScale = .4f;

    // DEBUG
    public bool _DebugPerlinField = false;

    void Start()
    {
        _RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_State == State.Idle)
        {
            // Don't move while idle timer accumulates
            _StateTimer += Time.deltaTime;

            // If idle timeout is up then start to wander
            if (_StateTimer >= _IdleTimeoutDuration)
                SetState(State.Wander);

            if(ExperienceManager.Instance != null)
                ExperienceManager.Instance._DebugText[1].text = "Echidna - State: Idle.  Timer: " + _StateTimer + " / " + _IdleTimeoutDuration;
        }
        else if (_State == State.BeingPushed)
        {
            // Don't move while idle timer accumulates
            _StateTimer += Time.deltaTime;

            // If idle timeout is up then start to wander
            if (_StateTimer >= _PushingTimeoutDuration)
                SetState(State.Idle);

        }
        else if (_State == State.Seeking)
        {
            // Seek toward target distraction
            ExperienceManager.Instance._DebugReadouts[1].text = "Echidna - State: Seeking. Active Distraction Object: ";
        }
        else if (_State == State.Wander)
        {
            // Wander aimlessly until you come across a distraction
            _PerlOffset = Time.time * .1f;
            AddPerlinForce(transform.position, _BasePerlfieldScaler, _BasePerlForceScaler, _PerlOffset);

            // if stuck in one spot too long change the perl offset
            ExperienceManager.Instance._DebugReadouts[2].text = "Echidna - State: Wandering.";
        }
    }

    void SetState(State state)
    {
        if(state == State.Idle)
        {
            _State = state;
            _StateTimer = 0;
        }
        else if (state == State.BeingPushed)
        {
            _State = state;
            _StateTimer = 0;
        }
        else if(state == State.Seeking)
        {
            _State = state;
            _StateTimer = 0;
        }
        else if (state == State.Wander)
        {
            _State = state;
            _StateTimer = 0;
        }

        //print(name + " State set to: " + _State.ToString());
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

    #region Interactable interface methods
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void BeginInteraction(PlayerController player)
    {
        _PushingCount++;
        SetState(State.BeingPushed);
    }

    public void ContinueInteraction(PlayerController player)
    {

    }

    public void EndInteraction(PlayerController player)
    {
        _PushingCount--;

        if (_PushingCount == 0)
            SetState(State.Idle);
    }
    #endregion

    private void OnDrawGizmos()
    {
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
