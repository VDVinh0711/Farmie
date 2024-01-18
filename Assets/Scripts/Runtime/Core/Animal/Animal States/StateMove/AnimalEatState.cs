
using UnityEngine;

public class AnimalEatState :IState
{

    private AnimalBehavor _animalBehavor;
    private float currentimeEat = 0;

    public AnimalEatState(AnimalBehavor animalBehavor)
    {
        _animalBehavor = animalBehavor;
    }

    public void OnUpdate()
    {
        Debug.Log(_animalBehavor.MoveAnimal.checkIncome());
        if (_animalBehavor.MoveAnimal.checkIncome())
        {
            _animalBehavor.AnimationAnimal.OnAnimationIdle();
            Eatting();
            return;
        }
        _animalBehavor.MoveAnimal.isMove = true;
        _animalBehavor.AnimationAnimal.OnAnimationMove(_animalBehavor.MoveAnimal.Direction);
        _animalBehavor.MoveAnimal.Move();
       
    }

    public void OnEnter()
    {
        Debug.Log("run");
        _animalBehavor.MoveAnimal.isMove = true;
       _animalBehavor.MoveAnimal.UnregisterMoveRand();
       _animalBehavor.MoveAnimal.RegisterMovetarget();
       
    }

    public void OnExit()
    {
        _animalBehavor.IsEat = false;
        currentimeEat = 0;

    }

    private void Eatting()
    {
        
        currentimeEat++;
        if(currentimeEat <1000.0f) return;
        Debug.Log("Run");
        _animalBehavor.Animal.Stable.Trough.HasFood = false;
        _animalBehavor.IsEat = false;
    }
}
