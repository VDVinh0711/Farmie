using System;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

using PlayerManager = Player.PlayerManager;

public class CrafSystem : MonoBehaviour,IInterac,ITimeTracker
{

    #region Variable
    [SerializeField] private List<ItemCraf> _listItemCrafs = new ();
    [SerializeField] private Item_SO _itemCrafted;
    [SerializeField] private int currentIndex;
    [SerializeField] private PlayerManager _player;
    [SerializeField] private bool _canGet = false;
    [SerializeField] private bool isCraft = false;
    [SerializeField] private int timeCraft = 0;
    [SerializeField] private int _maxQuantityCreate ;
    [SerializeField] private int _quantityCreat;
    [SerializeField] private UI_Craft _uiCraft;
    public PlayerManager PlayerManager => _player;
    public List<ItemCraf> ListItemCraf => _listItemCrafs;
    public Item_SO ItemCrafted => _itemCrafted;
    public int QuantityCreate => _quantityCreat;
    public ItemCraf ItemCrafCurrent => _listItemCrafs[currentIndex];
    public bool IsCraf => isCraft;
    public   Bag _bag => _player.Bag;
    public bool Canget => _canGet;
    public Action<int> ActionChangeTImeUI;
    public Action ActionChangeUIDes;
    public Action ActionChangeQuantityCreate;
    public Action ActionChaneButtonGet_Craft;
    

    #endregion
   

    private void Start()
    {
        TimeManager.Instance.RegisterTracker(this);
        ChangeActive(0);
        
    }

    #region Craf

    public void Craf()
    {
        if(!ItemCrafCurrent.enoughItem) return;
       
        foreach (var item in ItemCrafCurrent.ItemCraftSo.Materials)
        {
            _bag.BagController.GetItemInBagById(item.ItemSo.ID, item.quantity * _quantityCreat);
        }
        timeCraft = (ItemCrafCurrent.ItemCraftSo.timeCraf) * _quantityCreat;
        isCraft = true;
        _itemCrafted =  ItemCrafCurrent.ItemCraftSo.itemCrafted;

    }
    private void CrafrEnd()
    {
        isCraft = false;
        _canGet = true;
        OnStateChangeButton_Craft_Get();
        TimeManager.Instance.UregisterTracker(this);
    }
    public void CheckItemCraft( int index)
    {
        ItemCraf itemCraf = _listItemCrafs[index];
        foreach (var meterial in itemCraf.ItemCraftSo.Materials)
        {
            string idmete = meterial.ItemSo.ID;
            print("Count item of bag" + _bag.CountItem(idmete));
            print("Item of Meterial " +   meterial.quantity);
            if (_bag.CountItem(idmete) < meterial.quantity)
            {
                itemCraf.enoughItem = false;
                break;
            }
            else
            {
                itemCraf.enoughItem = true;
            }
               
        }
    }
    public void CheckAllItem()
    {
        for (int i = 0; i < _listItemCrafs.Count; i++)
        {
            CheckItemCraft(i);
        }
    }

    #endregion
    #region Controller

    
    private void GetMaxquantityCreate()
    {
        var ListRq = new List<int>();
        foreach (var item in ItemCrafCurrent.ItemCraftSo.Materials)
        {
            var iteminBag = _bag.CountItem(item.ItemSo.ID);
            ListRq.Add((iteminBag/item.quantity));
        }
        ListRq.Sort();
        _maxQuantityCreate = ListRq[0];
    }
    public void GetItemCrafIntoBag()
    {
        _player.Bag.AddItem(_itemCrafted, _maxQuantityCreate);
        _canGet = false;
    }
    public void ChangeActive(int index)
    {
        ItemCrafCurrent.IsActive = false;
        currentIndex = index;
        ItemCrafCurrent.IsActive = true;
        _quantityCreat = 0;
        GetMaxquantityCreate();
        OnStateChangeDes();
        OnStateChangeUIQuantity();
        OnStateChangeButton_Craft_Get();
    }
    public void AddQuantityCreate()
    {
        var quantityadd = _quantityCreat + 1;
        _quantityCreat = _quantityCreat >= _maxQuantityCreate ? _maxQuantityCreate : quantityadd;
        OnStateChangeUIQuantity();
    }
    public void PreviousQuantityCreate()
    {
        var quantitypre = _quantityCreat  -1;
        _quantityCreat = _quantityCreat  <= 0 ? 0 : quantitypre;
        OnStateChangeUIQuantity();
    }
    private void OnStateChangeUITIme()
    {
        ActionChangeTImeUI?.Invoke(timeCraft);
    }
    private void OnStateChangeDes()
    {
        ActionChangeUIDes?.Invoke();
    }
    private void OnStateChangeUIQuantity()
    {
        ActionChangeQuantityCreate?.Invoke();
    }

    private void OnStateChangeButton_Craft_Get()
    {
        ActionChaneButtonGet_Craft?.Invoke();
    }
    #endregion
    public void InterRac(PlayerManager playerManager)
    {
        _player = playerManager;
        CheckAllItem();
        _uiCraft.ToggleUICraf();
    }
    public void CLockUpdate(GameTime gameTime)
    {
        if(!isCraft) return;
        if (timeCraft < 0)
        {
            CrafrEnd();
        }
        timeCraft -= 1;
        OnStateChangeUITIme();
    }
}

[Serializable]
public class ItemCraf
{

    private bool isActive =false    ;
    public ItemCraft_SO ItemCraftSo;
    public bool enoughItem;
   
    public bool IsActive
    {
        set
        {
            isActive = value;
            OnStateChangeUI();
        }
        get => isActive;
    }
    public Action<ItemCraf> OnActionChange;

    private void OnStateChangeUI()
    {
        OnActionChange?.Invoke(this);
    }
}
