
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum State
{
    Menu,
    LevelSelect,
    Playing,
    Paused,
    Cutscene,
    Complete
}

public class ExperienceManager : MonoBehaviour
{
    [HideInInspector]
    public State _State;

    public static ExperienceManager Instance;

    public GameObject _ScoreScreen;

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        // Display score UI
        _State = State.Complete;
        _ScoreScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Master", LoadSceneMode.Single);
    }


}
