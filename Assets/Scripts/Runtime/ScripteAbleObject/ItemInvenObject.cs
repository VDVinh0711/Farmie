
using UnityEngine;
[CreateAssetMenu(menuName = "New ItemData/Item Inventory")]
public class ItemInvenObject : ItemObject,IStackAble
{
    [SerializeField]
    private float _price;
    public float Price =>_price;
    public int MaxStack { get=>6; }
}
