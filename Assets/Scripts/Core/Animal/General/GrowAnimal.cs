using System;
using UnityEngine;

public class GrowAnimal : MonoBehaviour,ITimeTracker
{
    [SerializeField] private Animal _animal;
    [SerializeField] private float _timeGrow = 0;
    [SerializeField] private float _timeHarvest = 0;
    [SerializeField] private bool _matured = false;

    public float TimeGrow
    {
        get => _timeGrow;
        set
        {
            _timeGrow = value >= 0 ? value : 0;
        }
    }
    
    public event Action<float> StateChangeTime;

    private void Start()
    {
        RegisterTime();
        _animal = GetComponent<Animal>();
        SetTime();
    }

    public void SetTimeDefautHarvest()
    {
        _timeHarvest = _animal.AnimalObject.TimeHarvest;
    }
    private void SetTime()
    {
        //_timeGrow = GameTime.MinutetoSecond(GameTime.HourInMinute(GameTime.DaytoHour(_animal.AnimalObject.DaytoGrow)));
        _timeGrow = 10;
        _animal.UiAnimal.RegisterInfor(_timeGrow);
        _timeHarvest = _animal.AnimalObject.TimeHarvest ;
    }

    public void RegisterTime()
    {
        TimeManager.Instance.RegisterTracker(this);
    }
    public  void Grow()
    {
        if(_matured) return; 
        if (_animal.IsSick) return;
        float  scaletime = _animal.IsHurry ?  0.5f : 1f;
        _timeGrow-=scaletime;
        OnStateChangeTime();
        if (_timeGrow >0 ) return;
        _matured= true;  
    }

    private void CountdownHarvest()
    {
        if(!_matured) return;
        if (_animal.IsSick) return;
        if(_animal.IsHarvest) return;
        _timeHarvest--;
        if(_timeHarvest >0) return;
        _animal.PhysiologicalState.IsHarvest = true;
    }
    
    private void OnStateChangeTime()
    {
        StateChangeTime?.Invoke(_timeGrow);
    }
    public void CLockUpdate(GameTime gameTime)
    {
        Grow();
        CountdownHarvest();
    }
    private void OnDestroy()
    {
        TimeManager.Instance.UregisterTracker(this);
    }
}
