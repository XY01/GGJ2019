
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum State
{
    TitleScreen,
    Paused,
    Playing,
    Complete
}

public class ExperienceManager : MonoBehaviour
{
    [HideInInspector]
    public State _State;

    public static ExperienceManager Instance;

    // HUD
    public Text _TimeReadout;

    // Debug
    public Text _EchidnaDebug;
    public Text[] _PlayerDebugs;
    public Text _Message;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("ScoreScreen", LoadSceneMode.Single);
        }
    }


}
