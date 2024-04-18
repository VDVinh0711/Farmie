using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollingObject : Singleton<PollingObject>
{
    [SerializeField] private Transform _Holders;
    [SerializeField] private List<Transform> _objHolders = new();

    
    
    public void AddPooling(Transform obj)
    {
        obj.gameObject.SetActive(false);
        obj.SetParent(_Holders);
        _objHolders.Add(obj);
    }
    
    public Transform GetObj(string name)
    {
        var obj = _objHolders.Find(obj => obj.gameObject.name.Contains(name));
        if (obj == null) return null;
        _objHolders.Remove(obj);
        return obj;
    }
}
