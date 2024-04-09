using System;

using UnityEngine;
using Object = UnityEngine.Object;

[CreateAssetMenu(menuName = "New ItemData/Aricultural")]
[Serializable]
public class AgriculturalSo : EquidmentSo
{
    [SerializeField] private int _maxdurability;
    [SerializeField]private AriculturalType _typeAricul;
    [SerializeField] private int _reduceDura;
    public int MaxDurability => _maxdurability;
    public int ReduceDura => _reduceDura;
    public int CurrentDura;
    public AriculturalType TypeAricul => _typeAricul;
    
    
    public override void Used(Object land)
    {
        ;
        var landuse = land as Land;
      
        if(landuse == null) return;
        switch (_typeAricul)
        {
            case AriculturalType.Cut: 
                landuse.Harvest();
                break;
            case AriculturalType.WaterCan:
                landuse.WateringPlant();
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
