using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void Explode()
    {
        Debug.Log("Explosion");
        Money.Instance.DecreaseMoney(50);
    }
}
