
using UnityEngine;
using Object = UnityEngine.Object;


public abstract class EquidmentSo :Item_SO
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
