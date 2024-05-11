
using System.Collections;
using UnityEngine;
using Random = System.Random;

public class SoundAnimal : MonoBehaviour
{
    private int timerandStart  =3;
    private int timerandEnd  =20;
    private Animal _animal;
    private void Start()
    {
        _animal = GetComponent<Animal>();
        GameManager.Instance.SoundGameManager.AddSoundSFX(_animal.AnimalObject.name,_animal.AnimalObject.Sound);
        StartCoroutine(PlaysoundAnimal());
    }

    IEnumerator PlaysoundAnimal()
    {
        while (true)
        {
            Random random = new Random();
            yield return new WaitForSeconds(random.Next(timerandStart, timerandEnd));
            GameManager.Instance.SoundGameManager.PlayMussicSFXsound(_animal.AnimalObject.name);
        }
       
    }
}
