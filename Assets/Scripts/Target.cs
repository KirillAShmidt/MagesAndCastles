using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(InteractableObject))]
public class Target : MonoBehaviour, IInteractable
{
    public IHaveHealth target;

    public void ExecuteInteraction()
    {
        /*if(Player.ActiveUnit != null)
        {
            Debug.Log("TargetSet");
            Player.ActiveUnit.GetComponent<Unit>().SetNewTarget(GetComponent<IHaveHealth>());
        }*/
    }
}
