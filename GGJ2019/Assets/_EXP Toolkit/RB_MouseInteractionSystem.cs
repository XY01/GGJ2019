using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_MouseInteractionSystem : MonoBehaviour
{
    public Camera _Cam;
    public float _DistFromCamera = 1;
    Vector3 _MouseInWorld;

    public Vector3 _Velocity;
   
    RB_MouseInteractionBehavior _ActiveObject;
    public RB_MouseInteractionBehavior ActiveObject { get { return _ActiveObject; } }
    List<RB_MouseInteractionBehavior> _InteractionObjects = new List<RB_MouseInteractionBehavior>();

    private void Start()
    {
        if (_Cam == null)
            _Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Udpate mouse position
        Vector3 newMousePos = _Cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _DistFromCamera));
        _Velocity = Vector3.Lerp(_Velocity, (newMousePos - _MouseInWorld) / Time.deltaTime, Time.deltaTime * 10);

        _MouseInWorld = newMousePos;

        if (_ActiveObject == null) return;
        if(_ActiveObject._State == RB_MouseInteractionBehavior.ObjectState.Grasped)
        {
            _ActiveObject.transform.position = _MouseInWorld;
        }
    }
    
    public void SetActiveObject(RB_MouseInteractionBehavior obj)
    {
        _DistFromCamera = _Cam.transform.InverseTransformPoint(obj.transform.position).z;// Vector3.Distance(obj.transform.position, _Cam.transform.position);
        _ActiveObject = obj;
    }

    public void RemoveActiveObject(RB_MouseInteractionBehavior obj)
    {
        if (_ActiveObject == obj)
            _ActiveObject = null;
    }

    public void RegisterObejct(RB_MouseInteractionBehavior obj)
    {
        _InteractionObjects.Add(obj);
    }

    public void UnregisterObejct(RB_MouseInteractionBehavior obj)
    {
        _InteractionObjects.Remove(obj);
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(_MouseInWorld, _MouseInWorld + _Velocity);
    }
}
