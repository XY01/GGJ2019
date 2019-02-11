using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Chaser : MonoBehaviour
{
    private Vector3 _StarterPoint;
    public float _RangeMax;
    private NavMeshAgent _Nav;
    public PlayerController[] _Players;
    // Update is called once per frame
    private void Start()
    {
        _StarterPoint = transform.position;
        _Nav = GetComponent<NavMeshAgent>();
        _Players = FindObjectsOfType<PlayerController>();
    }
    void Update()
    {
        _Players = FindObjectsOfType<PlayerController>();
        //Debug.Log(_Players[0].transform.position);

        foreach (PlayerController player in _Players)
        {
            //Debug.Log(Vector3.Distance(player.transform.position, _StarterPoint));
            if(Vector3.Distance(player.transform.position, _StarterPoint) < _RangeMax)
            {
                _Nav.destination = player.transform.position;
                Debug.Log("Should be moving");
            }
            else
            {
                _Nav.destination = _StarterPoint;
            }
        }
    }
}
