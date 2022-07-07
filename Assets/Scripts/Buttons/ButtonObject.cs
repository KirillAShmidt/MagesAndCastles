using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonObject : MonoBehaviour
{
    public int price;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        Money.Instance.OnMoneyChanged += ChangeState;
    }

    private void ChangeState()
    {
        if (Money.Instance.ShowMoney() < price)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
