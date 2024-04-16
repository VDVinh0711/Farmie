
using System;
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
        public int CurrentStack { get; set; }
        public void DecreseStacK(int quantity)
        {
            if (CurrentStack > quantity) return;
            CurrentStack -= quantity;
        }

        public int AddStack(int quantity)
        {
            var numberloss = MaxStack - CurrentStack;
            if (quantity > numberloss)
            {
                CurrentStack = MaxStack;
                return quantity - numberloss;
            }

            CurrentStack += quantity;
            return 0;
        }

      
    }

    public enum AnimalType
    {
        Unknown,
        Cattle,
        Poultry
    }
}