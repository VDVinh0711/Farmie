
using System.Collections.Generic;
using UnityEngine;

using InventorySystem;
using Player;

public class Shop : MonoBehaviour,IInterac
{
    public List<ItemShopObject> itemShop = new List<ItemShopObject>();
    [SerializeField]  private UIShop _uishop;
    [SerializeField] private PlayerManager _playerManager;
    public PlayerManager PlayerManager => _playerManager;
    
    public  void Purchare(ItemShopObject item , int quantity)
    {
        float toltalcoast = item.Price * quantity;
        if (toltalcoast >  PlayerManager.Instance.PlayerStats.Money) EventManger<string>.RaiseEvent("ShowNotifycation","Bạn không có đủ tiền");
        switch (item)
        {
            case AnimalShopObject  animalshopobj:
                var stable = GameObject.Find(animalshopobj.animalObject.nameLocationSpawn).GetComponent<Stable>();
                if (stable.AddAnimal(quantity, animalshopobj.animalObject))  _playerManager.PlayerStats.Spend(toltalcoast);
                break;
            case Itemshop itemdata:
                var bag = _playerManager.Bag;
                var itemadd = ItemHelper.MappingItem(itemdata.itemdata, 0);
                if ( !bag.AddItem(itemadd, quantity)) return;
                _playerManager.PlayerStats.Spend(toltalcoast);
                break;
        }
    }

    public void InterRac(PlayerManager playerManager)
    {
        print("Interact");
        _playerManager = playerManager;
        if (_uishop == null) _uishop = FindObjectOfType<UIShop>();
        _uishop.OpenUiShop(itemShop);
    }
}
