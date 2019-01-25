using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    public bool _TargetMainCamera;
    public GameObject _Target;
    void Update()
    {
        if(_TargetMainCamera == true)
        {
            transform.LookAt(Camera.main.transform.position);
        }
        else
        {
            transform.LookAt(_Target.transform.position);
        }
       
    }
}
