
using Player;
using UnityEngine;

public class SellAnimal : MonoBehaviour
{
    private Animal _animal;

    private float price;
    private void Start()
    {
        _animal = transform.GetComponent<Animal>();
    }

    public float getpriceSell()
    {
        var timegrow = GameTime.MinutetoSecond(GameTime.HourInMinute(GameTime.DaytoHour(_animal.AnimalObject.DaytoGrow)));
        var pricepersecond =_animal.AnimalObject.cost/timegrow  ;
        price = Mathf.RoundToInt( (timegrow / _animal.GrowAnimal.TimeGrow) * 50) ;
        return price;
    }
    public void sellAnimal()
    {
        PlayerController.Instance.PlayerStats.Earn(price);
        EventManger<Object>.RaiseEvent("CheckMission",_animal.AnimalObject);
        Destroy(_animal.gameObject);
    }
    
}
