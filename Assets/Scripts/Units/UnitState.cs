public abstract class UnitState
{
    public Unit unit;

    public UnitState(Unit unit)
    {
        this.unit = unit;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
