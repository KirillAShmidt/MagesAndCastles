using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffButton : MonoBehaviour
{
    public State nextState;

    public void GetState()
    {
        GameManager.Instance.ChangeState(nextState);
    }
}
