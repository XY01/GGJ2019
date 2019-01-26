using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Initialise();
    }

    void Initialise()
    {
        GameObject.FindWithTag("FadeImage").SetActive(false);
        ExperienceManager.Instance._State = State.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
