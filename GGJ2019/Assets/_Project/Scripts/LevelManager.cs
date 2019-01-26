using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float _TimeTaken;

    void Start()
    {
        PlayerPrefs.SetFloat("Score", 0);
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
            PlayerPrefs.SetFloat("Score", _TimeTaken);
            ExperienceManager.Instance._TimeReadout.text = _TimeTaken.ToString("F1");
        }
    }


    AsyncOperation loadMaster;

    IEnumerator LoadMaster()
    {
        loadMaster = SceneManager.LoadSceneAsync("Master", LoadSceneMode.Additive);
        while (!loadMaster.isDone)
        {
            yield return null;
        }
        ExperienceManager.Instance._State = State.Playing;
    }
}
