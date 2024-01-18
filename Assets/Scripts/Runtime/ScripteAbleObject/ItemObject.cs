
using System;
using UnityEngine;

public abstract class ItemObject : ScriptableObject
{
    [SerializeField] private string _id;
    //[SerializeField] private bool _isStackAble;
    [SerializeField] private Sprite _uiinGame;
    [SerializeField] private Sprite _uiinInven;
    [SerializeField] private string _descriptionVN;
    [SerializeField] private string _descriptionEN;
   // public bool isStackAble=>_isStackAble;
    public Sprite UIinGame => _uiinGame;
  
    public Sprite UIinInven => _uiinInven;
    public string DescriptionVN => _descriptionVN;
    public string DescriptionEN => _descriptionEN;
    public string ID => _id;
    
    public static ItemObject getItemByID(string id)
    {
        var itemlist = Resources.LoadAll<ItemObject>( "");
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

