using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 _Rotation;
    public Space _Space = Space.Self;
    
	void Update ()
    {
        transform.Rotate(_Rotation.x * Time.deltaTime,
            _Rotation.y * Time.deltaTime,
            _Rotation.z * Time.deltaTime, _Space);
		
	}
}
