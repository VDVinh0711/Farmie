
using System;
using System.Collections.Generic;
using UnityEngine;

public class PhysiologicalState : MonoBehaviour,ITimeTracker
{
    [SerializeField] private bool _isnormal;
    [SerializeField] private bool _ishurry;
    [SerializeField] private bool _issick;
    [SerializeField] private bool _isharvest;
    private AnimalNormalState _animalNormalState;
    private AnimalHurryState _animalHurryState;
    private AnimalHarvestState _animalHarvestState;
    private AnimalSickState _animalSickState;
    public List<IState> listState = new();

    [SerializeField] private float timeEat ;
    [SerializeField] private float health ;
    public Animal Animal;


   [SerializeField]  private Stable _stable;
    public Stable Stable => _stable;

    public event Action<PhysiologicalState> ChangeStateAnimal;
    public float TimeEat
    {
        get => timeEat;
        set
        {
            timeEat = value >= 0 ? value : 0;
        }
    }
    public float Health
    {
        get => health;
        set
        {
            health = value >= 0 ? value : 0;
        }
    }
    public bool IsNormal
    {
        get => _isnormal;
        set
        {
            _isnormal = value;
            if (value)
            {
                _ishurry = false;
                _issick = false;
               _animalNormalState.OnEnter();
               
            }
            else
            {
                _animalNormalState.OnExit();
            }
            NotifyChangeStateAnimal();
        }
    }
    public bool IsHurry
    {
        get => _ishurry;
        set
        {
            _ishurry = value;
            if (value)
            {
                _isnormal = false;
                _animalHurryState.OnEnter();
              
            }
            else
            {
                
                _animalHurryState.OnExit();
                if (!_issick)
                {
                    IsNormal = true;
                }
            }
            NotifyChangeStateAnimal();
        }
    }

    public bool IsSick
    {
        get => _issick;
        set
        {
            _issick = value;
            if (value)
            {
                _isnormal = false;
               _animalSickState.OnEnter();
            }
            else
            {
                _animalSickState.OnExit();
                if (!_ishurry)
                {
                    IsNormal = true;
                }
            }
            
            NotifyChangeStateAnimal();
        }
    }

    public bool IsHarvest
    {
        get => _isharvest;
        set
        {
            _isharvest = value;
            if (value)
            {
                _isnormal = false;
                _animalHarvestState.OnEnter();
                
            }
            else
            {
                
                if (!_ishurry || !_issick)
                {
                    IsNormal = true;
                }
                _animalHarvestState.OnExit();
            }
        }
    }


    private void Awake()
    {
        _stable = transform.GetComponentInParent<Stable>();
        Animal = transform.GetComponent<Animal>();
        _animalNormalState = new AnimalNormalState(this);
        _animalHurryState = new AnimalHurryState(this,timeEat);
        _animalSickState = new AnimalSickState(this,health);
        _animalHarvestState = new AnimalHarvestState(this);
        _isnormal = true;
        _ishurry = false;
        _issick = false;
        _isharvest = false;
        _animalNormalState.OnEnter();
        SetnormalState();
    }

    private void Start()
    {
        TimeManager.Instance.RegisterTracker(this);
    }
    
    public void CLockUpdate(GameTime gameTime)
    {
      
        if(listState.Count <= 0) return;
        for(int i=0;i<listState.Count;i++)
        {
            listState[i].OnUpdate();
        }
        
    }
    public void RegisterState(IState state)
    {
        if(listState.Contains(state)) return;
        listState.Add(state);
    }
    public void RemoveState(IState state)
    {
        if(!listState.Contains(state)) return;
        listState.Remove(state);
    }

    private void OnExitState()
    {
        if (!_isnormal)
        {
            _animalNormalState.OnExit();
        }
        if (!_issick)
        {
            _animalSickState.OnExit();
        }
        if (!_ishurry)
        {
            _animalHurryState.OnExit();
        }
        if (!_isharvest)
        {
            _animalHarvestState.OnExit();
        }
        
    }
    
    public void SetData(float timeEat, float health)
    {
        this.timeEat = timeEat;
        this.health = health;
    }
   /* private void OnEnterState()
    {
        if (_isnormal)
        {
            SetnormalState();
        }
        if (_issick)
        {
            SetSickState();
        }
        if (_ishurry)
        {
            SetHurryState();
        }
        if (_isharvest)
        {
            SetHarvestState();
        }
    }*/

    private void SetnormalState()
    {
        _isnormal = true;
        _ishurry = false;
        _issick = false;
        _isharvest = false;
        _animalNormalState.OnEnter();
    }
    /*
    private void SetHurryState()
    {
        _ishurry = true;
        _isnormal = false;
        _animalHurryState.OnEnter();
    }
    private void SetSickState()
    {
        _issick = true;
        _isnormal = false;
        _animalSickState.OnEnter();
    }
    private void SetHarvestState()
    {
        _isharvest = true;
        _isnormal = false;
        _animalHarvestState.OnEnter();
    }*/

    private void NotifyChangeStateAnimal()
    {
        ChangeStateAnimal?.Invoke(this);
    }


    private void OnDestroy()
    {
        TimeManager.Instance.UregisterTracker(this);
    }
}
