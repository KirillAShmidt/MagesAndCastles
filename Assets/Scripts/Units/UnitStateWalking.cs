using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateWalking : UnitState
{
    public UnitStateWalking(Unit unit) : base(unit)
    {
        this.unit = unit;
    }

    public override void Enter() 
    {
        unit.agent.isStopped = false;
        unit.animator.SetTrigger(unit.WALK);

        Debug.Log(unit.name + " walking");
    }
    public override void Update() 
    {

        if (unit.Target != null)
        {
            unit.agent.SetDestination(unit.Target.ReturnTransform().position);
        }

        if (unit.Target != null && Vector3.Distance(unit.Target.ReturnTransform().position, unit.transform.position) <= unit.hitDistance)
        {
            unit.ProvokeTarget();

            unit.ChangeState(unit.fightingState);
        }
    }

    public override void Exit() 
    {
        unit.animator.ResetTrigger(unit.IDLE);
    }
}
