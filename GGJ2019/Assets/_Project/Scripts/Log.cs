using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{ 
    public int _HealthMax;
    public GameObject[] _Segments;
    //Finds out if broken
    public bool Broken()
    {
        if(_HealthMax > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    void BreakLog()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        foreach (GameObject segment in _Segments)
        {
            segment.SetActive(true);
            segment.GetComponent<Rigidbody>().isKinematic = false;
        }
        
    }
    private void Update()
    {
        if(Broken() == true)
        {
            BreakLog();             
        }
    }

}
