using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(InteractableObject))]
public class Bonus : MonoBehaviour, IInteractable
{
    public void ExecuteInteraction()
    {
        Money.Instance.IncreaseMoney(10);

        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
