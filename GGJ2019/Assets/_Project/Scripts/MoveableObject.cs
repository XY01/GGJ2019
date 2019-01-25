using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour, iInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginInteraction(PlayerController player)
    {
        // turn rb to is kinematic
        // play pick up particles or animation
    }

    public void StopInteraction(PlayerController player)
    {
        // turn rb to isnt kinematic
        // play put down particles or animation
    }

}
