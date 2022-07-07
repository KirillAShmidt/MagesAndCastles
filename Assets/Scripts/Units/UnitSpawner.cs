using UnityEngine;
using System;
using System.Collections.Generic;

public class UnitSpawner : MonoBehaviour
{
    public static UnitSpawner Instance;

    public Action<Unit> OnUnitSpawned;

    private void Awake()
    {
        Instance = this;
    }

    public Unit SpawnAndReturn(Unit unit, Vector3 position)
    {
        return Instantiate(unit, position, Quaternion.identity);
    }

    public void SpawnUnit(Unit unit, Vector3 position)
    {
        var clone = Instantiate(unit, position, Quaternion.identity);

        OnUnitSpawned?.Invoke(clone);
    }

    private Transform FindCastle(Unit unit)
    {
        var castles = FindObjectsOfType<Castle>();

        foreach (var castle in castles)
        {
            if(castle.camp == unit.camp)
            {
                return castle.transform;
            }
        }

        return null;
    }
}
