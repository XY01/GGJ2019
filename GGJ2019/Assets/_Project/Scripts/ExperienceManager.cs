using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public enum State
    {
        Menu,
        LevelSelect,
        Playing,
        Paused,
        Cutscene,
    }

    State _State = State.Playing;
    State CurrentState { get { return _State; } }



    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
