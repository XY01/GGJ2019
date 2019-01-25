using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make sure game is in focus otherwise mic won't work

public class MicInput : MonoBehaviour
{
    public static MicInput Instance { get; set; }

    public static float MicLoudness;
    public static float MicLoudnessinDecibels;

    private string _device;

    public int _DeviceIndex = 2;

    public float _Cutoff = .5f;

    public Vector2 _NormalizeRange = new Vector2(0, 0);
    public float Norm { get{ return MicLoudness.ScaleTo01(_NormalizeRange.x, _NormalizeRange.y); } }
    public float SmoothedNorm;

    public float _SmoothUp = 0;
    public float _SmoothDown = 6;


    AudioClip _clipRecord;
    AudioClip _recordedClip;
    int _sampleWindow = 128;

    //mic initialization
    public void InitMic()
    {
        for (int i = 0; i < Microphone.devices.Length; i++)
        {
            print("Mic input devices: ("+i+")" + Microphone.devices[i]);
        }

        if (_device == null)
        {
            print("Starting : " + Microphone.devices[_DeviceIndex]);        
            _device = Microphone.devices[_DeviceIndex];
        }

        _clipRecord = Microphone.Start(_device, true, 999, 44100);
        _isInitialized = true;
    }

    public void StopMicrophone()
    {
        Microphone.End(_device);
        _isInitialized = false;
    }

    void Update()
    {
        // levelMax equals to the highest normalized value power 2, a small number because < 1
        // pass the value to a static var so we can access it from anywhere
        MicLoudness = MicrophoneLevelMax();

        if (Norm > SmoothedNorm)
        {
            if (_SmoothUp != 0)
                SmoothedNorm = Mathf.Lerp(SmoothedNorm, Norm, Time.deltaTime * _SmoothUp);
            else
                SmoothedNorm = Norm;
        }
        else
        {
            if (_SmoothUp != 0)
                SmoothedNorm = Mathf.Lerp(SmoothedNorm, Norm, Time.deltaTime * _SmoothDown);
            else
                SmoothedNorm = Norm;
        }
    }


    //get data from microphone into audioclip
    float MicrophoneLevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1); // null means the first microphone
        if (micPosition < 0) return 0;
        _clipRecord.GetData(waveData, micPosition);

        // Getting a peak on the last 128 samples
        for (int i = 0; i < _sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }

    //get data from microphone into audioclip
    float MicrophoneLevelMaxDecibels()
    {
        float db = 20 * Mathf.Log10(Mathf.Abs(MicLoudness));
        return db;
    }

    public float FloatLinearOfClip(AudioClip clip)
    {
        StopMicrophone();

        _recordedClip = clip;

        float levelMax = 0;
        float[] waveData = new float[_recordedClip.samples];

        _recordedClip.GetData(waveData, 0);
        // Getting a peak on the last 128 samples
        for (int i = 0; i < _recordedClip.samples; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }

    public float DecibelsOfClip(AudioClip clip)
    {
        StopMicrophone();

        _recordedClip = clip;

        float levelMax = 0;
        float[] waveData = new float[_recordedClip.samples];

        _recordedClip.GetData(waveData, 0);
        // Getting a peak on the last 128 samples
        for (int i = 0; i < _recordedClip.samples; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }

        float db = 20 * Mathf.Log10(Mathf.Abs(levelMax));

        return db;
    }


    bool _isInitialized;
    // start mic when scene starts
    void OnEnable()
    {
        InitMic();
        _isInitialized = true;
        Instance = this;
    }

    //stop mic when loading a new level or quit application
    void OnDisable()
    {
        StopMicrophone();
    }

    void OnDestroy()
    {
        StopMicrophone();
    }


    // make sure the mic gets started & stopped when application gets focused
    void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            //Debug.Log("Focus");

            if (!_isInitialized)
            {
                //Debug.Log("Init Mic");
                InitMic();
            }
        }
        if (!focus)
        {
            //Debug.Log("Pause");
            StopMicrophone();
            //Debug.Log("Stop Mic");

        }
    }
}
