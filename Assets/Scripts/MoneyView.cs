using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        ChangeText();
        Money.Instance.OnMoneyChanged += ChangeText;
    }

    private void ChangeText()
    {
        text.text = text.text = Money.Instance.ShowMoney().ToString();
    }
}
