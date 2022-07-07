using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Castle : MonoBehaviour, IHaveHealth
{
    public Camp camp;
    public float health;

    public Action OnDamageTaken;
    public event Action OnDied;

    public float CurrentHealth { get; set; }

    private void Awake()
    {
        CurrentHealth = health;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        OnDamageTaken?.Invoke();

        if (CurrentHealth <= 0)
            Die();
    }

    public Transform ReturnTransform()
    {
        return transform;
    }

    public GameObject ReturnGameObject()
    {
        return gameObject;
    }

    public void Die()
    {
        OnDied?.Invoke();

        GameManager.Instance.ChangeState(State.end);

        Destroy(gameObject);
    }
}
