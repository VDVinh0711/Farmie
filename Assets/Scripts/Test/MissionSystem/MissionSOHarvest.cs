
using UnityEngine;
namespace MissionSystem
{
    
    [CreateAssetMenu(menuName = "New Mission / MissionHarvest")]
    public class MissionSOHarvest : MissionSO
    {
        public ItemObject ItemObject;
        
        protected override void OnValidate()
        {
            base.OnValidate();
        }
    }
}

