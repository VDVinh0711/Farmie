




public class AnimalRunState :  IState
{
    private AnimalBehavor _animalBehavor;

    public AnimalRunState(AnimalBehavor animalBehavor)
    {
        _animalBehavor = animalBehavor;
    }
    public void OnUpdate()
    {
        _animalBehavor.AnimationAnimal.OnAnimationMove(_animalBehavor.MoveAnimal.Direction);
        _animalBehavor.MoveAnimal.Move();
    }

    public void OnEnter()
    {
        _animalBehavor.MoveAnimal.isMove = true;
        _animalBehavor.MoveAnimal.UnregisterMoveTarget();
        _animalBehavor.MoveAnimal.RegisterMoveRandom();
    }
    

    public void OnExit()
    {
      
    }
   
     
   
    
    
    
    
}
