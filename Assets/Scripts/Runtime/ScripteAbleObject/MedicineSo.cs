
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Data
{
    [CreateAssetMenu(menuName = "New ItemData/Medicine Animal")]
    public class MedicineSo:EquidmentSo,IStackAble
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
    
}