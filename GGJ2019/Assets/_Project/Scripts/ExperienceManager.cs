
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

    public void Restart()
    {
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }

    public void Quit()
    {
        //If we are running in a standalone build of the game
        #if UNITY_STANDALONE
            //Quit the application
            Application.Quit();
        #endif

        //If we are running in the editor
        #if UNITY_EDITOR
            //Stop playing the scene
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }


}
