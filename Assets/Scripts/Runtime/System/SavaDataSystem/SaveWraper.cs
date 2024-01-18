
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
            /*if (Input.GetKeyDown(KeyCode.Z))
            {
                Save();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
                print("Load");
            }*/
        }

        public void Save()
        {
            var saveSystems = FindObjectsOfType<SavingSystem>();
            foreach (var saveAble in saveSystems)
            {
                saveAble.LoadSaveData();
            }
        }

        public void Load()
        {
           var saveSystems = FindObjectsOfType<SavingSystem>();
            foreach (var saveAble in saveSystems)
            {
                saveAble.LoadData();
            }
        }
        
    } 
}

