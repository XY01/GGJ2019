using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EchidnaInteractable : MonoBehaviour
{
    public enum Type
    {
        Food,
        Booze,
    }

    public Type _Type = Type.Food;
    public float _EffectStrength = 1;
    public float TimeToConsume { get { return _EffectStrength * 5; } }
}
