

using UnityEngine;

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
        Debug.Log(_physiologicalState.IsSick || _physiologicalState.Stable.Trough.HasFood);
        if(_physiologicalState.IsSick || _physiologicalState.Stable.Trough.HasFood) return;
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
