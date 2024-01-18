
using UnityEngine;
namespace Data
{
    [CreateAssetMenu(menuName = "New ItemData/Medicine Animal")]
    public class MedicineObject:EquidmentObject,IStackAble
    {
        public override void Used(Object data)
        {
            var animal = data as Animal;
            if(animal == null) return;
            animal.PhysiologicalState.IsSick = false;
        }
        public int MaxStack
        {
            get => 99;
        }
    }
    
}