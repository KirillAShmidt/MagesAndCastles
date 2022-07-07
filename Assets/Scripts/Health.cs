using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Health : MonoBehaviour
{
    [SerializeField] private Castle _castle;

    private Slider healthSlider;

    private void Awake()
    {
        healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = _castle.health;
        healthSlider.value = _castle.health;

        _castle.OnDamageTaken += ChangeHealth;
    }

    public void ChangeHealth()
    {
        healthSlider.value = _castle.CurrentHealth;
    }
}
