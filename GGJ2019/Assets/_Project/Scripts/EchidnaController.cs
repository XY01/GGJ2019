using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EchidnaController : MonoBehaviour, iInteractable
{
    enum State
    {
        Idle,
        Wander,
        Seeking,
        BeingPushed,
    }

    State _State = State.Idle;
    Rigidbody _RB;

    public float _IdleTimeoutDuration = 3;
    float _IdleTimer = 0;

    float _DrunkenessNorm = 0;  // How much booze he has drank
    float _FullnessNorm = 0;    // How much food he has eaten

    // Movement noise
    float _PerlinOffset = 0;
    public float _BasePerlForceScaler = 1;
    public float _BasePerlfieldScaler = 1;

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
        AddPerlinForce(transform.position, _BasePerlfieldScaler, _BasePerlForceScaler);
        /*
        if (_State == State.Idle)
        {
            // Don't move. 
            _IdleTimer += Time.deltaTime;

            // If idle timeout is up then start to wander
            if (_IdleTimer >= _IdleTimeoutDuration)
                SetState(State.Wander);
        }
        else if (_State == State.BeingPushed)
        {

        }
        else if (_State == State.Seeking)
        {

        }
        else if (_State == State.Wander)
        {

        }
        */
    }

    void SetState(State state)
    {
        if(state == State.Idle)
        {

        }
        else if (state == State.BeingPushed)
        {

        }
        else if(state == State.Seeking)
        {

        }
        else if (state == State.Wander)
        {

        }
    }

    // Perlin force and movement
    void AddPerlinForce(Vector3 pos, float perlfieldScaler, float forceScaler)
    {
        _RB.AddForce(GetPerlinForce(pos, perlfieldScaler, forceScaler));
    }

    Vector3 GetPerlinForce(Vector3 pos, float perlfieldScaler, float forceScaler)
    {
        Vector3 perlForce = Vector3.zero;
        perlForce.x = Mathf.PerlinNoise(pos.x * perlfieldScaler, pos.z * perlfieldScaler).ScaleFrom01(-1f, 1f);
        perlForce.z = Mathf.PerlinNoise((pos.x + 1.234f) * perlfieldScaler, (pos.z - 2.3454f) * perlfieldScaler).ScaleFrom01(-1f, 1f);

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
        // turn rb to is kinematic
        // play pick up particles or animation
    }

    public void ContinueInteraction(PlayerController player)
    {
    }

    public void EndInteraction(PlayerController player)
    {
        // turn rb to isnt kinematic
        // play put down particles or animation
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
                    Debug.DrawLine(vecPos, vecPos + GetPerlinForce(vecPos, _BasePerlfieldScaler, _BasePerlForceScaler) * .2f);
                }
            }
        }
    }
}
