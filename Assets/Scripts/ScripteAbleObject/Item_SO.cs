
using System;
using UnityEngine;

public abstract class Item_SO : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private Sprite _uiinGame;
    [SerializeField] private Sprite _uiinInven;
    [SerializeField] private string _keyDes;
   
    public Sprite UIinGame => _uiinGame;
  
    public Sprite UIinInven => _uiinInven;
  
    public string KeyDes => _keyDes;
    public string ID => _id;
    
    public static Item_SO getItemByID(string id)
    {
        var itemlist = Resources.LoadAll<Item_SO>( "");
        foreach (var item in itemlist)
        {
            if (item.ID == id)
                return item;
        }
        return null;
    }

    private void OnValidate()
    {
        _id = this.name;
    }
}

