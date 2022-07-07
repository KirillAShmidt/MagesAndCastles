using System;
using UnityEngine;

public class UnitButton : ButtonObject
{
    public Action OnPlayerUnitSpawned;

    [SerializeField] private Unit _prefab;
    [SerializeField] private Transform _transform;

    public void GiveSpawning()
    {
        OnPlayerUnitSpawned?.Invoke();
    }

    public void Spawn()
    {
        UnitSpawner.Instance.SpawnUnit(_prefab, _transform.position);
    }
}
