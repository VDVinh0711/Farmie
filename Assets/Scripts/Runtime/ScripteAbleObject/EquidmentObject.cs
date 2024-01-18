
using UnityEngine;
using Object = UnityEngine.Object;


public abstract class EquidmentObject :ItemObject
{
    [SerializeField] private EquidmentType Type;
    public EquidmentType EquidmentType => Type;


    public abstract void Used(Object data);
}
public enum EquidmentType
{
    none,
    Agricultural,
    Seed,
    Food,
    Medicine
}
