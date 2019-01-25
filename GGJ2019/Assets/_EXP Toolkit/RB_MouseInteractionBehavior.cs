using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using EXPToolkit;

// Default > Hovered > Grasped > Default
// ................. > Default

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class RB_MouseInteractionBehavior : MonoBehaviour, iInteractionBehavior
{
    #region Interface implimentation
    public event EventHandler OnBeginHover;
    public event EventHandler OnStayHovered;
    public event EventHandler OnEndHover;

    public event EventHandler OnBegingGrasp;
    public event EventHandler OnStayGrasped;
    public event EventHandler OnEndGrasp;

    public void BeginHover() { OnBeginHover?.Invoke(this, null); }
    public void StayHovered() { OnStayHovered?.Invoke(this, null); }
    public void EndHover() { OnEndHover?.Invoke(this, null); }

    public void BeginGrasp() { OnBegingGrasp?.Invoke(this, null); }
    public void StayGrasped() { OnStayGrasped?.Invoke(this, null); }
    public void EndGrasped() { OnEndGrasp?.Invoke(this, null); }
    #endregion


    public enum ObjectState
    {
        Default,
        Hovered,
        Grasped,
    }

    public ObjectState _State = ObjectState.Default;

    Rigidbody _RB;

    public bool _IsKinematic = false;
    bool _WasKinematic = false;

    RB_MouseInteractionSystem _InteractionSystem;

    public float _VelScaler = .5f;

    private void Start()
    {
        _InteractionSystem = FindObjectOfType<RB_MouseInteractionSystem>();
        _InteractionSystem.RegisterObejct(this);
        _RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {       
        if (_State == ObjectState.Hovered)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetState(ObjectState.Grasped);
            }
            else
            {
                StayHovered();
            }
        }
        else if (_State == ObjectState.Grasped)
        {
            // if letting go of the mouse, end grasping
            if (Input.GetMouseButtonUp(0))
            {
                SetState(ObjectState.Default);
            }
            else
            {
                StayGrasped();
            }
        }
    }

    void SetState(ObjectState state)
    {
        if(state == ObjectState.Default)
        {
            _InteractionSystem.RemoveActiveObject(this);

            if (_State == ObjectState.Hovered)
            {
                EndHover();
            }
            else if (_State == ObjectState.Grasped)
            {
                _RB.isKinematic = _WasKinematic;
                _RB.velocity = _InteractionSystem._Velocity * _VelScaler;
                EndGrasped();
            }
        }
        else if (state == ObjectState.Hovered)
        {
            _InteractionSystem.SetActiveObject(this);
            BeginHover();
        }
        else if (state == ObjectState.Grasped)
        {
            _WasKinematic = _RB.isKinematic;
            _RB.isKinematic = _IsKinematic;
            
            BeginGrasp();
        }

        //print("States set too from: " + _State + "   " + state);
        _State = state;
    }

    private void OnDisable()
    {
        _InteractionSystem.UnregisterObejct(this);
    }

    void OnMouseEnter()
    {
        if (_InteractionSystem.ActiveObject == null && _State == ObjectState.Default)
            SetState(ObjectState.Hovered);
    }

    void OnMouseOver()
    {
        if (_InteractionSystem.ActiveObject == null && _State == ObjectState.Default)
            SetState(ObjectState.Hovered);
    }

    void OnMouseExit()
    {
        if(_State == ObjectState.Hovered)
            SetState(ObjectState.Default);
    }
}
