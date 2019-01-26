using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iInteractable
{
    void BeginInteraction(PlayerController player);
    void StopInteraction(PlayerController player);
    GameObject GetGameObject();
}
