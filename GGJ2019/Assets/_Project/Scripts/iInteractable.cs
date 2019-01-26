using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iInteractable
{
    void BeginInteraction(PlayerController player);
    void ContinueInteraction(PlayerController player);
    void EndInteraction(PlayerController player);    
    GameObject GetGameObject();
}
