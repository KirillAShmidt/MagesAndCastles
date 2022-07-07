using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Money : MonoBehaviour
{
    [SerializeField] private int _money;

    private int _currentMoney;

    public static Money Instance;
    public Action OnMoneyChanged;

    private void Awake()
    {
        Instance = this;

        _currentMoney = _money;
    }

    public void DecreaseMoney(int price)
    {
        _currentMoney -= price;

        OnMoneyChanged?.Invoke();
    }

    public void IncreaseMoney(int money)
    {
        _currentMoney += money;

        OnMoneyChanged?.Invoke();
    }

    public int ShowMoney()
    {
        return _currentMoney;
    }
}
