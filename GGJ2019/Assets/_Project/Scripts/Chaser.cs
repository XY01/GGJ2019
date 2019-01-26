using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Chaser : MonoBehaviour
{
    public GameObject StarterPoint;
    public float _RangeMax;
    private NavMeshAgent _Nav;
    public PlayerController[] _Players;
    public ParticleSystem _AlertParticle;
    // Update is called once per frame
    private void Start()
    {
        _Nav = GetComponent<NavMeshAgent>();
        _Players = FindObjectsOfType<PlayerController>();
    }
    void Update()
    {
        _Players = FindObjectsOfType<PlayerController>();
        Debug.Log(_Players[0].transform.position);

        foreach (PlayerController player in _Players)
        {
            Debug.Log(Vector3.Distance(player.transform.position, StarterPoint.transform.position));
            if(Vector3.Distance(player.transform.position, StarterPoint.transform.position) < _RangeMax)
            {
                _Nav.destination = player.transform.position;
                _AlertParticle.Emit(1);
                Debug.Log("Should be moving");
            }
            else
            {
                _Nav.destination = StarterPoint.transform.position;
            }
        }
    }
}
