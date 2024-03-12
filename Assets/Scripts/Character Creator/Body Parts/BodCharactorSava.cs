using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodCharactorSava
{
    public Dictionary<string, SO_body_part> _ListBodyParts = new Dictionary<string, SO_body_part>();
    

    public void Set(string name, SO_body_part soBodyPart)
    {
        if(!_ListBodyParts.ContainsKey(name)) return;
        _ListBodyParts[name] = soBodyPart;
    }
}
