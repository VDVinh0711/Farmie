using UnityEngine;
public class AnimalInterac : MonoBehaviour,IInterac
{
    [SerializeField]
    private Animal animal;
    [SerializeField]
    private AnimalBehavor _animalBehavor;
    [SerializeField]
    private UiAnimal _uianimal;
    private void Start()
    {
        animal = GetComponent<Animal>();
        _uianimal = transform.GetComponent<UiAnimal>();
        _animalBehavor = GetComponent<AnimalBehavor>();
    }
    public void InterRac()
    {
        _uianimal.ShowUIinfor();
    }
}

