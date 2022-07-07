using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Bonus _prefab;

    private Unit _unit;

    private void Start()
    {
        _unit = GetComponent<Unit>();
        _unit.OnDied += SpawnBonus;
    }

    public void SpawnBonus()
    {
        Instantiate(_prefab, _unit.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    }
}
