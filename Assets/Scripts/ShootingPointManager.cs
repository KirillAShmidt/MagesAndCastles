using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootingPointManager : MonoBehaviour
{
    [SerializeField] private List<ShootingPoint> points;

    public static ShootingPointManager Instance;

    private bool _isSelectable;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowVacantPlaces()
    {
        foreach (var point in points)
        {
            if(point.canon == null)
            {
                point.ChangeState(ShootingPointState.Selectable);
                point.ShowAsSelectable();
            }
        }
    }

    public void HideVacantPlaces()
    {
        foreach(var point in points)
        {
            point.ChangeState(ShootingPointState.NotSelectable);
            point.HideAsSelectable();
        }
    }

    public void SwitchState()
    {
        if (_isSelectable)
        {
            HideVacantPlaces();
            _isSelectable = false;
        }
        else
        {
            ShowVacantPlaces();
            _isSelectable = true;
        }
    }
}
