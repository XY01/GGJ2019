using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float _TimeTaken;

    void Start()
    {
        Initialise();
    }

    void Initialise()
    {
        // Keep entry directly from scene working
        Scene master = SceneManager.GetSceneByName("Master");

        if (!master.isLoaded)
        {
            StartCoroutine(LoadMaster());
        }
    }

    private void Update()
    {
        if (ExperienceManager.Instance != null &&  ExperienceManager.Instance._State == State.Playing)
        {
            _TimeTaken += Time.deltaTime;
            ExperienceManager.Instance._TimeReadout.text = _TimeTaken.ToString("F2");
        }
    }


    AsyncOperation asyncLoadLevel;

    IEnumerator LoadMaster()
    {
        asyncLoadLevel = SceneManager.LoadSceneAsync("Master", LoadSceneMode.Additive);
        while (!asyncLoadLevel.isDone)
        {
            yield return null;
        }
        ExperienceManager.Instance._State = State.Playing;
    }
}
