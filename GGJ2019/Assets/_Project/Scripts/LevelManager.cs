using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Initialise();
    }

    void Initialise()
    {
        //GameObject.FindWithTag("FadeImage").SetActive(false);

        Scene master = SceneManager.GetSceneByName("Master");

        if (!master.isLoaded)
        {
            StartCoroutine(LoadMaster());

        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    AsyncOperation asyncLoadLevel;

    IEnumerator LoadMaster()
    {
        asyncLoadLevel = SceneManager.LoadSceneAsync("Master", LoadSceneMode.Additive);
        while (!asyncLoadLevel.isDone)
        {
            print("Loading the Scene");
            yield return null;
        }
        GameObject.FindGameObjectWithTag("MenuUI").SetActive(false);
        ExperienceManager.Instance._State = State.Playing;
    }
}
