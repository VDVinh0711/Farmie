
using UnityEngine;
using UnityEngine.Serialization;

namespace MissionSystem
{
    
    [CreateAssetMenu(menuName = "New Mission / MissionHarvest")]
    public class MissionSOHarvest : MissionSO
    {
        [FormerlySerializedAs("ItemObject")] public Item_SO itemSo;
        
        protected override void OnValidate()
        {
            base.OnValidate();
        }
    }
}

