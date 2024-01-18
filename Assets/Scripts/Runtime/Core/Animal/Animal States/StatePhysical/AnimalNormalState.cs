

public class AnimalNormalState : IState
{
    private PhysiologicalState _physiologicalState;
    public AnimalNormalState(PhysiologicalState physiologicalState)
    {
        _physiologicalState = physiologicalState;
    }
    public void OnUpdate()
    {
        _physiologicalState.TimeEat -= 1;
        if(_physiologicalState.TimeEat > 0) return;
        _physiologicalState.IsHurry = true;
    }

    public void OnEnter()
    {
        _physiologicalState.RegisterState(this);
    }

    public void OnExit()
    {
        _physiologicalState.RemoveState(this);

    }
}
