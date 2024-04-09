
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "New ItemData/Seed")]
public class SeedSo : EquidmentSo,IStackAble
{
    [SerializeField]
    private int _daytoGrow;
    [SerializeField]
    private List<Sprite> _spriteGrow;
    [SerializeField]
    private Item_SO _itemHarvset;

    public int DaytoGrow => _daytoGrow;
    public List<Sprite> SpriteGrow => _spriteGrow;
    public Item_SO ItemHarvest => _itemHarvset;

    public override void Used(UnityEngine.Object data)
    {
        var land = data as Land;
        if(land == null) return;
        land.SeedingPlant(this);
    }


     [SerializeField] public int MaxStack { get => 6; }
}
