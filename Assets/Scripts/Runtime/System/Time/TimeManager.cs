using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>,ISaveSystem
{
    [SerializeField] GameTime gameTime;
    public float timeScale = 1.0f;
    //List of Object to inform of changes to the time
    [SerializeField]
    List<ITimeTracker> listeners = new List<ITimeTracker>();
    private void Start()
    {
        if(gameTime== null)  gameTime = new GameTime(0, GameTime.Season.spring, 1, 0, 0,0);
        StartCoroutine(TimeUpDate());
    }


    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator TimeUpDate()
    {
        while(true)
        {
            yield return new  WaitForSeconds(1 / timeScale);
            Tick();
        }
    }    
    public void Tick()
    {
        gameTime.UpdateTime();
        //Inform the listener of the new time state
        foreach(ITimeTracker listener in  listeners)
        {
            listener.CLockUpdate(gameTime);
        }
    } 

    //Get GameTime
    public GameTime  GetGameTime()
    {
        return new GameTime(this.gameTime);
    }

    //Handel listener
    public void RegisterTracker(ITimeTracker listener)
    {
        this.listeners.Add(listener);
    }
    //Remove the object from the list of listner
    public void UregisterTracker(ITimeTracker listner)
    {
        listeners.Remove(listner);
    }


    public object SaveData()
    {
        return gameTime;
    }

    public void LoadData(object state)
    {
        
        try
        {
            var time = JsonConvert.DeserializeObject<GameTime>(state.ToString());
            gameTime = new GameTime(time);
        }
        catch (JsonException ex)
        {
            Debug.LogError("Error deserializing GameTime from JSON: " + ex.Message);
        }
    }
}
