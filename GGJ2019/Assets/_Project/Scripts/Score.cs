using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public enum ScoreType
    {
        Score,
        HighScore,
    }
    public ScoreType _ScoreType;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("HighScore") < PlayerPrefs.GetFloat("Score"))
        {
            PlayerPrefs.SetFloat("HighScore", PlayerPrefs.GetFloat("Score"));
        }
        if (_ScoreType == ScoreType.Score)
        {
            GetComponent<Text>().text = PlayerPrefs.GetFloat("Score").ToString("F1");
        }
        else
        {
            GetComponent<Text>().text = PlayerPrefs.GetFloat("HighScore").ToString("F1");
        }
    }

}
