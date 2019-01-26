using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _ExperienceLoader : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene(SRScenes.Master, LoadSceneMode.Additive);
    }
}
