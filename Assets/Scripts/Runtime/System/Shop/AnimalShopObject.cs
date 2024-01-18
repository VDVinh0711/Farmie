
using UnityEngine;

[CreateAssetMenu(menuName = "New Item Shop / shop Animal")]
public class AnimalShopObject : ItemShopObject
{
     public AnimalObject animalObject;
      
    public static void SpawnAnimal(AnimalObject animalObj)
    {
        var animalSpawn = Instantiate(animalObj.model);
        animalSpawn.gameObject.SetActive(false);
        var animalScpript = animalSpawn.transform.GetComponent<Animal>();
        animalScpript.Instantiate(animalObj);
        animalSpawn.gameObject.SetActive(true);
    }
}
