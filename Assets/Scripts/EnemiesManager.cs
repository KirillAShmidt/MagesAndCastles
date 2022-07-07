using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager Instance;

    private List<Unit> enemies = new List<Unit>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddUnitInManagerList(Unit unit)
    {
        enemies.Add(unit);
    }
}
