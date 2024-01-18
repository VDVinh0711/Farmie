
using System.Collections.Generic;
using UnityEngine;

using InventorySystem;
using Player;

public class Shop : MonoBehaviour,IInterac
{
    public List<ItemShopObject> itemShop = new List<ItemShopObject>();
    [SerializeField]
    private UIShop _uishop;
    private Transform farm;
    public static void Purchare(ItemShopObject item , int quantity)
    {
        float toltalcoast = item.Price * quantity;
        if (toltalcoast >  PlayerController.Instance.PlayerStats.Money)
        {
            EventManger<string>.RaiseEvent("ShowNotifycation","Bạn không có đủ tiền");
        }
        if (item is AnimalShopObject)
        {
            var animalshopobj = item as AnimalShopObject;
            var stable = GameObject.Find(animalshopobj.animalObject.nameLocationSpawn).GetComponent<Stable>();
           if (stable.AddAnimal(quantity, animalshopobj.animalObject))
            {
                PlayerController.Instance.PlayerStats.Spend(toltalcoast);
            }
           
        }
        if(item is Itemshop)
        {
            Itemshop itemdata = item as Itemshop;
            if (BagsManager.Instance.AddItem(itemdata.itemdata, quantity))
            {
                PlayerController.Instance.PlayerStats.Spend(toltalcoast);
            }
          
        }
    }
    public void InterRac()
    {
       if(_uishop == null) _uishop = GameObject.FindAnyObjectByType<UIShop>();
       _uishop.Shop.InstantiateShop(itemShop);
       _uishop.OpenUiShop();

    } 
    
}
