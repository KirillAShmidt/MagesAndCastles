using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class AggressiveBehavior : MonoBehaviour
{
    [SerializeField] private float _radius;

    private Unit unit;

    private void Start()
    {
        unit = GetComponent<Unit>();
    }

    private void Update()
    {
        var colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var collider in colliders)
        {
            var enemy = collider.GetComponent<Unit>();

            if (enemy != null && enemy.camp != unit.camp && enemy != unit)
            {
                unit.SetNewTarget(enemy.GetComponent<Unit>());
            }
        }
    }
}
