using System;

using UnityEngine;
using Object = UnityEngine.Object;

[CreateAssetMenu(menuName = "New ItemData/Aricultural")]
[Serializable]
public class AgriculturalObject : EquidmentObject
{
    [SerializeField] private int _durability;
    [SerializeField]private AriculturalType _typeAricul;
    [SerializeField] private int _reduceDura;
    public int Durability => _durability;
    public AriculturalType TypeAricul => _typeAricul;
    public int ReduceDura => _reduceDura;

    public override void Used(Object land)
    {
        var landuse = land as Land;
        if(landuse == null) return;
        switch (_typeAricul)
        {
            case AriculturalType.Cut: 
                EventManager.RaisEvent("Harvest" + landuse.ID);
                break;
            case AriculturalType.WaterCan:
               EventManager.RaisEvent("Watering" + landuse.ID);
                break;
            default:
                break;
        }
    }
}
public enum AriculturalType
{
   Unknow,
   Cut,
   WaterCan
}
