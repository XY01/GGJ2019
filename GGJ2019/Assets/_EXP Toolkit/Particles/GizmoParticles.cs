using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoParticles : MonoBehaviour
{
    public static GizmoParticles Instance;
    public ParticleSystem _PS;
    public ParticleSystem.EmitParams _Emit;

    private void Awake()
    {
        Instance = this;
        _PS = GetComponent<ParticleSystem>();
        _Emit = new ParticleSystem.EmitParams();
    }

    public void Emit(Vector3 pos, Vector3 vel)
    {
        _Emit.position = pos;
        _Emit.velocity = vel;       
    }

    public void Emit(Vector3 pos, int count)
    {
        _Emit.ResetVelocity();
        _PS.transform.position = pos;
        _PS.Emit(_Emit, count);
    }

}
