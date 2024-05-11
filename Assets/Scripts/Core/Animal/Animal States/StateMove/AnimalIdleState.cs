

public class AnimalIdleState : IState
{
    private AnimalBehavior _animalBehavior;

    public AnimalIdleState(AnimalBehavior animalBehavior)
    {
        _animalBehavior = animalBehavior;
    }
    public void OnUpdate()
    {
       //Run Logic  Idel Animal
    }

    public void OnEnter()
    {
        _animalBehavior.MoveAnimal.isMove = false;
        _animalBehavior.MoveAnimal.SetRotation();
        _animalBehavior.AnimationAnimal.OnAnimationIdle();
    }

    public void OnExit()
    {
        _animalBehavior.MoveAnimal.ResetRotation();
    }
}
