

public class AnimalHurryState : IState
{
    private PhysiologicalState _physiologicalState;
    private float _timeEat;
    public AnimalHurryState(PhysiologicalState physiologicalState,float timeEat)
    {
        _physiologicalState = physiologicalState;
        _timeEat = timeEat;

    }
    public void OnUpdate()
    {
        if(_physiologicalState.IsSick) return;
        _physiologicalState.Health -= 1;
        if(_physiologicalState.Health >0) return;
        _physiologicalState.IsSick = true;
    }

    public void OnEnter()
    {
       _physiologicalState.RegisterState(this);
    }

    public void OnExit()
    {
        _physiologicalState.TimeEat = _timeEat;
        _physiologicalState.RemoveState(this);
    
    }

    
}
