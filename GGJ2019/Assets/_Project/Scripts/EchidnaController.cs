using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EchidnaController : MonoBehaviour
{
    public float _ControllableRadius = 1.5f;

    float _CurrentScale = .4f;
    float _BaseScale = .4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, transform.localScale.x * _ControllableRadius);
    }
}
