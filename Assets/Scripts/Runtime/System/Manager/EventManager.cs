using System;

using System.Collections.Generic;


public static class EventManager
{
    private static readonly Dictionary<string, Action> events = new();
    public static void RaisEvent(string nameEvent)
    {
        if(!events.ContainsKey(nameEvent)) return;
        events[nameEvent]?.Invoke();
    }

    public static void RegisterEvent(string eventname , Action action)
    {
        if (events.ContainsKey(eventname))
        {
            events[eventname] += action;
        }
        else
        {
            events.Add(eventname,action);
        }
    }

    public static void RemoveListener(string eventname, Action action)
    {
        if (events.ContainsKey(eventname))
        {
            events[eventname] -= action;
            if (events[eventname] == null)
            {
                events.Remove(eventname);
            }
        }
    }

    public static void RemoveAllListener()
    {
        events.Clear();
    }
}
public static class EventManger<T>
{
    private static readonly Dictionary<string, Action<T>> events = new();


    public static void RaiseEvent(string nameevent, T data)
    {
        if(!events.ContainsKey(nameevent)) return;
        events[nameevent]?.Invoke(data);
    }

    public static void Registerevent(string nameevent , Action<T> action)
    {
        if (events.ContainsKey(nameevent))
        {
            events[nameevent] += action;
        }
        else
        {
            events.Add(nameevent,action);
        }
    }

    public static void Removeevent(string nameevent, Action<T> action)
    {
        if (events.ContainsKey(nameevent))
        {
            events[nameevent] -= action;
            if (events[nameevent] == null)
            {
                events.Remove(nameevent);
            }
        }
    }
    public static void RemoveAllListener()
    {
        events.Clear();
    }
}
