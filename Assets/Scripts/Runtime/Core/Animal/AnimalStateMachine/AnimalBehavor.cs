using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

enum State
{
    idle,
    run,
    eat
}
public class AnimalBehavor : MonoBehaviour
{
    private StateMachine _stateMachine;
    private AnimalRunState _animalRunState;
    private AnimalEatState _animalEatState;
    private AnimalIdleState _animalIdleState;
    private MoveAnimal _moveAnimal;
    private Animal _animal;
    private AnimationAnimal _animationAnimal;
    [SerializeField]private bool _iseat;
    [SerializeField] private bool _isNormal;
    [SerializeField] private bool _isIdle;
    public MoveAnimal MoveAnimal => _moveAnimal;
    public Animal Animal => _animal;
    public AnimationAnimal AnimationAnimal => _animationAnimal;
    [SerializeField] private State animaleState;
    [SerializeField] private PhysiologicalState _physiological;
    [SerializeField] private int numberandom = 2;
    public PhysiologicalState PhysiologicalState => _physiological;
    public bool Isnormal
    {
        get => _isNormal;
        set
        {
            _isNormal = value;
            if (value)
            {
                animaleState = State.run;
            }
           
        }
    }
    public bool IsEat
    {
        get => _iseat;
        set
        {
            _iseat = value;
            if (value)
            {
                animaleState = State.eat;
            }
            else
            {
                Isnormal = true;
                RemoveStateEat();
            }
        }
    }
    public bool IsIdle
    {
        get => _isIdle;
        set
        {
            _isIdle = value;
            if (value)
            {
                animaleState = State.idle;
            }
        }
    }
    private void Awake()
    {
        _stateMachine = new StateMachine();
        _animalRunState = new AnimalRunState(this);
        _animalEatState = new AnimalEatState(this);
        _animalIdleState = new AnimalIdleState(this);
        _moveAnimal = GetComponent<MoveAnimal>();
        _animationAnimal = GetComponent<AnimationAnimal>();
        _physiological = GetComponent<PhysiologicalState>();
       At(_animalRunState, _animalEatState, () => _iseat);
       At(_animalRunState,_animalIdleState,()=>_isIdle);
       At(_animalEatState,_animalRunState,()=>_isNormal);
       At(_animalIdleState,_animalRunState,()=>_isNormal);
       At(_animalIdleState, _animalEatState, () => _iseat);
        _stateMachine.SetState(_animalRunState);
        void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
        GetComponent();
    }

    private void Start()
    {
       StartCoroutine(WaitChangeState());
    }

    private void FixedUpdate()
    {
        _stateMachine.OnUpdate();
        Changestate();
    }

    private void GetComponent()
    {
        _moveAnimal = transform.GetComponent<MoveAnimal>();
        _animal = transform.GetComponent<Animal>();
    }
    IEnumerator WaitChangeState()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(3.0f,6.0f));
            if (!_iseat)
            {
                RandomState();
            }
           
        }
    }
    private  void RandomState()
    {
        int number = Random.Range(0,numberandom);
        animaleState = (State)number;
    }
    private void Changestate()
    {
        switch (animaleState)
        {
            case State.run:
                _isNormal = true;
                _iseat = false;
                _isIdle = false;
                break;
            case State.idle:
                _isNormal = false;
                _iseat = false;
                _isIdle = true;
                break;
            case State.eat:
                _isNormal = false;
                _iseat = true;
                _isIdle = false;
                break;
           
            default:
                break;
            
        }
    }
    public void SetStateEat()
    {
        numberandom = 3;
    }

    private void RemoveStateEat()
    {
        numberandom = 2;
    }
}
