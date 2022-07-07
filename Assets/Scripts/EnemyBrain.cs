using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [Header("Unit Properties")]
    [SerializeField] private Unit _prafab;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _duration;

    [Header("Canon Properties")]
    [SerializeField] private List<Canon> _canons;


    private float _timer;
    private int counter = 0;

    private void Start()
    {
        _timer = _duration;

        var playerButton = FindObjectOfType<UnitButton>();

        if (playerButton != null)
        playerButton.OnPlayerUnitSpawned += CountPlayerUnits;
    }

    public void CountPlayerUnits()
    {
        counter++;
    }

    private void FixedUpdate()
    {
        _timer -= Time.deltaTime;

        if( _timer < 0)
        {
            var clone = UnitSpawner.Instance.SpawnAndReturn(_prafab, _spawn.position);
            EnemiesManager.Instance.AddUnitInManagerList(clone);

            _timer = _duration;
        }

        if(counter == 3)
        {
            Debug.Log("SpawnedCanon");
            counter = 0;
        }
    }
}
