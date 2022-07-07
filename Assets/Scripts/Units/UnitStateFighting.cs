using UnityEngine;

public class UnitStateFighting : UnitState
{
    private float _attackTime = 0;

    public UnitStateFighting(Unit unit) : base(unit)
    {
        this.unit = unit;
    }

    public override void Enter() 
    {
        unit.agent.isStopped = true;
        unit.animator.SetTrigger(unit.IDLE);

        Debug.Log(unit.name + " fighting");
    }

    public override void Update() 
    {
        if (_attackTime <= 0)
        {
            unit.animator.ResetTrigger(unit.WALK);
            unit.Attack();

            _attackTime = unit.duration;
        }

        _attackTime -= Time.deltaTime;

        if (unit.Target != null && Vector3.Distance(unit.Target.ReturnTransform().position, unit.transform.position) >= unit.hitDistance)
        {
            unit.ChangeState(unit.walkingState);
        }

        if (unit.Target != null && Vector3.Distance(unit.Target.ReturnTransform().position, unit.transform.position) <= unit.hitDistance)
        {
            unit.ProvokeTarget();
        }

        var lookRotation = Quaternion.LookRotation(unit.Target.ReturnTransform().position - unit.transform.position).normalized;
        unit.transform.rotation = Quaternion.Slerp(unit.transform.rotation, lookRotation, 20f * Time.deltaTime);
    }

    public override void Exit() 
    {
        //unit.animator.ResetTrigger(unit.WALK);
    }
}
