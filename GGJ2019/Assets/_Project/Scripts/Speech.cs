using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speech : MonoBehaviour
{
    public string[] _SpeechText;
    public Text _OutputSpeech;
    public Animator _SpeechAnim;
    public GameObject _Echidna;
    float timer = 0;
    int randoTimeTillTalk;
    private void Start()
    {
        SetRandoTime();
    }
    private void Update()
    {
        transform.position = FindObjectOfType<EchidnaController>().gameObject.transform.position;
        timer += Time.deltaTime;
        if (timer >= randoTimeTillTalk)
        {
            Talk();
            timer = 0;
        }
    }
    void SetRandoTime()
    {
        randoTimeTillTalk = Random.Range(4, 20);
    }
    void Talk()
    {
        int selectedSpeech = Random.Range(0, _SpeechText.Length);
        _OutputSpeech.text = _SpeechText[selectedSpeech];
        _SpeechAnim.SetTrigger("Talk");
        SetRandoTime();
    }
}

