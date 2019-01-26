using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityParticles : MonoBehaviour
{
    public Rigidbody _Rb;
    private ParticleSystem _Ps;
    private ParticleSystem.EmissionModule _PsEmmission;

    private void Start()
    {
        _Ps = GetComponent<ParticleSystem>();
        _PsEmmission = _Ps.emission;
    }
    // Update is called once per frame
    void Update()
    {
        _PsEmmission.rate = _Rb.velocity.magnitude * 30;
        Debug.Log(_Rb.velocity.magnitude);
    }
}
