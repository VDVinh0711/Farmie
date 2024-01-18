
using UnityEngine;


[CreateAssetMenu(menuName = "New Animal / Animal")]
public class AnimalObject : ScriptableObject
{
    public string id;
    public int DaytoGrow;
    public float pricetoBuy;
    public float health;
    public float timetoEat;
    public Transform model;
    public string nameLocationSpawn;
    public float cost;
    public float TimeHarvest;
    public ItemObject Itemharvest;
    public AudioClip Sound;


    public static AnimalObject GetAnimalByID(string id)
    {
        var ListAniamal = Resources.LoadAll<AnimalObject>( "");
        foreach (var animal in ListAniamal )
        {
            if (animal.id.Equals(id))
            {
                return animal;
            }
        }
        return null;
    }
    private void OnValidate()
    {
        id = this.name;
    }
}
