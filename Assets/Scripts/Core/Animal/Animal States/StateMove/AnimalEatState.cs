
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class AnimalEatState :IState
{

    private AnimalBehavior _animalbehavior;
    private float currentimeEat = 0;
    private bool _isEating = false;
    public AnimalEatState(AnimalBehavior animalbehavior)
    {
        _animalbehavior = animalbehavior;
    }
    public void OnUpdate()
    {
        if (_animalbehavior.MoveAnimal.checkIncome())
        {
            _animalbehavior.AnimationAnimal.OnAnimationIdle();
            Eatting();
            return;
        }
        _animalbehavior.MoveAnimal.isMove = true;
        _animalbehavior.AnimationAnimal.OnAnimationMove(_animalbehavior.MoveAnimal.Direction);
        _animalbehavior.MoveAnimal.Move();
       
    }
    public void OnEnter()
    {
        _animalbehavior.MoveAnimal.isMove = true;
       _animalbehavior.MoveAnimal.UnregisterMoveRand();
       _animalbehavior.MoveAnimal.RegisterMovetarget();
       
    }
    public void OnExit()
    {
        _animalbehavior.IsEat = false;
        currentimeEat = 0;

    }
    private void Eatting()
    {
        
        currentimeEat++;
        if(currentimeEat <1000.0f) return;
      
    }

    private void EatDon()
    {
        _animalbehavior.Animal.Stable.Trough.HasFood = false;
        _animalbehavior.IsEat = false;
    }
}
