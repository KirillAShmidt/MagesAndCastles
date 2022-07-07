using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour, IInteractable
{
    [SerializeField] private Material _materialOnSelected;

    private SkinnedMeshRenderer _meshRenderer;
    private Material _defaultMaterial;
    private Unit _unit;

    public bool isAggressive;
    public bool isVisible;

    private void Awake()
    {
        _defaultMaterial = GetComponentInChildren<SkinnedMeshRenderer>().materials[0];
        _meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        _unit = GetComponent<Unit>();
    }

    public void ExecuteInteraction()
    {
        if (isVisible)
        {
            GetComponent<AggressiveBehavior>().enabled = true;
            isAggressive = true;
            PlayerUnitManager.Instance.MakePlayerUnitsRegular();
            Money.Instance.DecreaseMoney(20);
        }
    }

    public void MakeVisible()
    {
        if (_meshRenderer != null)
        {
            _meshRenderer.material = _materialOnSelected;
            isVisible = true;
        }
    }

    public void MakeRegular()
    {
        if (_meshRenderer != null)
        {
            _meshRenderer.material = _defaultMaterial;
            isVisible = false;
        }
    }
}
