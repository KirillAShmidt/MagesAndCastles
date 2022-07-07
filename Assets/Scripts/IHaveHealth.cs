using UnityEngine;
using System;

public interface IHaveHealth
{
    public event Action OnDied;
    public void TakeDamage(float damage);
    public void Die();
    public Transform ReturnTransform();
    public GameObject ReturnGameObject();
}
