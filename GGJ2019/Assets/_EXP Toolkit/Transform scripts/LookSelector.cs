using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookSelector : MonoBehaviour
{
    Transform _Selector;
    public string[] _TargetStrings;
    Transform[] _Targets;

    public bool _DebugChangeScale = false;

    bool _Initialized = false;

    public void Init()
    {
        _Targets = new Transform[2];
        for (int i = 0; i < _TargetStrings.Length; i++)
        {
            _Targets[i] = GameObject.Find(_TargetStrings[i]).transform;
        }

        _Initialized = true;
    }

    public void Update()
    {
        if (!_Initialized)
            Init();

      

       // if (_DebugChangeScale) GetSelection();
    }

    // Iterate through each target and check the dot product of the forward vector of the camera against 
    // the vector from the camera towards the target object. Return the index of the result
	int GetSelection ()
    {
        int selection = 0;
        float highestDot = -1;

        _Selector = Camera.main.transform;
        Vector3 selectionFwd = _Selector.forward.normalized;

        for (int i = 0; i < _Targets.Length; i++)
        {
            Vector3 toTarget = (_Targets[i].position - _Selector.position).normalized;
            float dot = Vector3.Dot(selectionFwd, toTarget);

            if(dot > highestDot)
            {
                highestDot = dot;
                selection = i;
            }
        }

        if (_DebugChangeScale)
        {
            for (int i = 0; i < _Targets.Length; i++)
            {
                if(selection == i) _Targets[i].transform.localScale = Vector3.one * 2f;
                else _Targets[i].transform.localScale = Vector3.one;
            }           
        }


        return selection;
	}
}
