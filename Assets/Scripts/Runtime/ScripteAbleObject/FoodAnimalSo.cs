
using UnityEngine;


namespace Data
{
    [CreateAssetMenu(menuName = "New ItemData/Food Animal")]
    public class FoodAnimalSo : EquidmentSo,IStackAble
    {
        [SerializeField]
        private AnimalType typeFood;
        public AnimalType TypeFood => typeFood;
        public override void Used(UnityEngine.Object trough)
        {
            if(!(trough is Trough)) return;
            (trough as Trough).HasFood = true;
        }

        public int MaxStack { get=>10; }
    }

    public enum AnimalType
    {
        Unknown,
        Cattle,
        Poultry
    }
}