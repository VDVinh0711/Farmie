
using UnityEngine;

public class AnimalSickState : IState
{
    private PhysiologicalState _physiologicalState;
    private float maxheal;
    
   
    public AnimalSickState(PhysiologicalState physiologicalState,float maxheal)
    {
        _physiologicalState = physiologicalState;
        this.maxheal = maxheal;
    }
    public void OnUpdate()
    {
       
    }
    public void OnEnter()
    {
       _physiologicalState.RegisterState(this);
      
    }

    public void OnExit()
    {
        Debug.Log("Run");
        _physiologicalState.Health = maxheal ;
        _physiologicalState.RemoveState(this);
    }
}
