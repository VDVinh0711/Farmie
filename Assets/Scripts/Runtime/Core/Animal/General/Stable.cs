
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;


public class Stable : MonoBehaviour,ISaveData
{

    private  int maxAnimal = 3;
    public int MaxAnimal =>maxAnimal;
    [SerializeField] private Transform _locationSpawn;
    [SerializeField] private Trough _trough;
   
   public Trough Trough => _trough;
   private void Start()
   {
       _trough = transform.GetComponentInChildren<Trough>();
   }


   public bool AddAnimal(int quantity, AnimalObject animalObject)
   {
      var currentanimal = _locationSpawn.childCount;
      if (currentanimal + quantity > maxAnimal)
      {
          EventManger<string>.RaiseEvent("ShowNotifycation","Chuồng đã đầy");
          return false;
      }
       for (int i = 0; i < quantity; i++)
       {
           var animalSpawn = Instantiate(animalObject.model, _locationSpawn);
           var animalScript = animalSpawn.GetComponent<Animal>();
           animalScript.Instantiate(animalObject); 
       }
       return true;
   }
   
   private void FixedUpdate()
   {
       SetStateEat();
   }

   public void SetStateEat()
   {
      if(_locationSpawn.childCount<=0) return;
       if(!_trough.HasFood) return;
       foreach (var animal in _locationSpawn.GetComponentsInChildren<Animal>())
       {
           if(!animal.IsHurry) continue;
           animal.AnimalBehavor.SetStateEat();
           return;
       }
   }

   public void UnsetStateEat()
   {
       if(_locationSpawn.childCount<=0) return;
       if(_trough.HasFood) return;
       foreach (var animal in _locationSpawn.GetComponentsInChildren<Animal>())
       { 
           if(!animal.IsHurry) continue;
           animal.AnimalBehavor.PhysiologicalState.IsHurry = false;
       }
   }
    public object SaveData()
    {
        var saveAnimal = new List<AnimalData>();
        foreach (var animal in _locationSpawn.GetComponentsInChildren<Animal>())
        {
            var animaldata = new AnimalData(animal.ID, animal.GrowAnimal.TimeGrow, animal.IsSick, animal.IsHurry, animal.IsNormal, animal.IsHarvest);
            saveAnimal.Add(animaldata);
        }
        return saveAnimal;
    }

    public void LoadData(object state)
    {
        var saveanimal = JsonConvert.DeserializeObject <List<AnimalData>>(state.ToString());
        foreach (var animalData in saveanimal)
        {
            var animalObj = AnimalObject.GetAnimalByID(animalData.ID);
            var animalSpawn = Instantiate(animalObj.model, _locationSpawn);
            var animalScript = animalSpawn.GetComponent<Animal>();
            animalScript.Instantiate(animalObj);
            animalScript.LoadDataAnimal(animalData);
        }
        
    }
}
