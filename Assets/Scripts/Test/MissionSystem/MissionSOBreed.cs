using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MissionSystem
{
    
    [CreateAssetMenu(menuName = "New Mission / MissionBreed")]
    public class MissionSOBreed : MissionSO
    {
        public AnimalObject AnimalObject;

        protected override void OnValidate()
        {
            base.OnValidate();
        }
    }
}

