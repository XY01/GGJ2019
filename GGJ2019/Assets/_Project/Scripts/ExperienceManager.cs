
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance;
    public Text _TimeReadout;
    private float _TimeTaken;
    public Text[] _DebugText;

    private void Awake()
    {
        Instance = this;
    }

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

    void Update()
    {
        if(CurrentState == State.Playing)
        {
            _TimeTaken += Time.deltaTime;
            _TimeReadout.text = _TimeTaken.ToString("F2");
        }
    }
}