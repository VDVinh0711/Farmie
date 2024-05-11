
public class AnimalRunState :  IState
{
    private AnimalBehavior _animalBehavior;

    public AnimalRunState(AnimalBehavior animalBehavior)
    {
        _animalBehavior = animalBehavior;
    }
    public void OnUpdate()
    {
        _animalBehavior.AnimationAnimal.OnAnimationMove(_animalBehavior.MoveAnimal.Direction);
        _animalBehavior.MoveAnimal.Move();
    }
    public void OnEnter()
    {
        _animalBehavior.MoveAnimal.isMove = true;
        _animalBehavior.MoveAnimal.UnregisterMoveTarget();
        _animalBehavior.MoveAnimal.RegisterMoveRandom();
    }
    
    public void OnExit()
    {
      //Do Action for Animation when Exit State Animal
    }
   
     
   
    
    
    
    
}
