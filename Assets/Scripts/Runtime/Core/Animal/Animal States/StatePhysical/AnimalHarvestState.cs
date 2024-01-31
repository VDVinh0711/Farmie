

public class AnimalHarvestState : IState
{
    private PhysiologicalState _physiologicalState;
    
    public AnimalHarvestState(PhysiologicalState physiologicalState)
    {
        _physiologicalState = physiologicalState;
    }
    public void OnUpdate()
    {
       
    }

    public void OnEnter()
    {
        _physiologicalState.RegisterState(this);
       // _physiologicalState.Animal.UiAnimal.ShowUiHarvest();
        _physiologicalState.Animal.UiAnimal.UiInfor.ShowButtonHarvest();
    }

    public void OnExit()
    {
     
        _physiologicalState.RemoveState(this);
       // _physiologicalState.Animal.UiAnimal.HideUiHarvest();
        _physiologicalState.Animal.UiAnimal.UiInfor.HideButtonHarvest();
    }
}
