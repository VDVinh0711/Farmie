

public class AnimalIdleState : IState
{
    private AnimalBehavor _animalBehavor;

    public AnimalIdleState(AnimalBehavor animalBehavor)
    {
        _animalBehavor = animalBehavor;
    }
    public void OnUpdate()
    {
       
    }

    public void OnEnter()
    {
        _animalBehavor.MoveAnimal.isMove = false;
        _animalBehavor.MoveAnimal.SetRotation();
        _animalBehavor.AnimationAnimal.OnAnimationIdle();
    }

    public void OnExit()
    {
        _animalBehavor.MoveAnimal.ResetRotation();
    }
}
