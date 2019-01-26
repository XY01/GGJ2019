using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    AsyncOperation asyncLoadLevel;

    void Start()
    {
        Initialise();
    }

    void Initialise()
    {

        Scene master = SceneManager.GetSceneByName("Master");

        if (!master.isLoaded)
        {
            StartCoroutine(LoadMaster());
        }
    }

    IEnumerator LoadMaster()
    {
        asyncLoadLevel = SceneManager.LoadSceneAsync("Master", LoadSceneMode.Additive);
        while (!asyncLoadLevel.isDone)
        {
            yield return null;
        }
        GameObject.FindGameObjectWithTag("MenuUI").SetActive(false);
        ExperienceManager.Instance._State = State.Playing;
    }
}
