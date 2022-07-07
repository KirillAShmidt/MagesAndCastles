using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPoint : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Material _materialOnSelected;

    public ShootingPointState state;
    public Canon canon;

    private void Start()
    {
        state = ShootingPointState.NotSelectable;
        gameObject.SetActive(false);
    }

    public void ExecuteInteraction()
    {
        switch (state)
        {
            case ShootingPointState.Selectable:
                InstallCanon();
                break;
            case ShootingPointState.NotSelectable:
                break;
        }
    }

    public void ShowAsSelectable()
    {
        gameObject.SetActive(true);
    }
    public void HideAsSelectable()
    {
        gameObject.SetActive(false);
    }

    public void ChangeState(ShootingPointState state)
    {
        this.state = state;
    }

    public void InstallCanon()
    {
        var clone = Instantiate(_prefab, transform.position, Quaternion.identity);

        canon = clone.GetComponent<Canon>();

        Money.Instance.DecreaseMoney(15);

        ShootingPointManager.Instance.HideVacantPlaces();
        ShootingPointManager.Instance.SwitchState();
    }
}
