using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void BeginInteraction(PlayerController player)
    {
        print(name + " doesn't override interaction");
    }

    public virtual void ContinueInteraction(PlayerController player)
    {
        print(name + " doesn't override interaction");
    }

    public virtual void EndInteraction(PlayerController player)
    {
        print(name + " doesn't override interaction");
    }
}
