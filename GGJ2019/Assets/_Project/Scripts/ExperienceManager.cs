
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum State
{
    Menu,
    LevelSelect,
    Playing,
    Paused,
    Cutscene,
}

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance;
    public Text _TimeReadout;
    private float _TimeTaken;

    public Text _EchidnaDebug;
    public Text[] _PlayerDebugs;
    public Text _Message;


    private void Awake()
    {
        Instance = this;
    }

    [HideInInspector]
    public State _State;

    void Update()
    {
        if(_State == State.Playing)
        {
            print("test");
            _TimeTaken += Time.deltaTime;
            _TimeReadout.text = _TimeTaken.ToString("F2");
        }
    }

}