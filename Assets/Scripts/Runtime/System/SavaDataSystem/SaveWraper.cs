
using UnityEngine;



namespace  SavingSystem
{
    public class SaveWraper : MonoBehaviour
    {
        private void Awake()
        {
          
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Save();
            }

        }

        public void Save()
        {
            var saveSystems = FindObjectOfType<SavingDataFarm>();
            saveSystems.LoadSaveData();
            var saveSystem2 = FindObjectOfType<SavingDataPlayer>();
            saveSystem2.LoadSaveData();
            
        }

       
        
    } 
}

