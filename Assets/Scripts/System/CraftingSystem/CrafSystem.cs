using System;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

using PlayerManager = Player.PlayerManager;

public class CrafSystem : MonoBehaviour,IInterac,ITimeTracker
{

    #region Variable
    [SerializeField] private List<ItemCraf> _listItemCrafs = new ();
    [SerializeField] private Item _itemCrafted;
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
    public Item ItemCrafted => _itemCrafted;
    public int QuantityCreate => _quantityCreat;
    public ItemCraf ItemCrafCurrent => _listItemCrafs[currentIndex];
    public bool IsCraf => isCraft;
    public   Bag _bag => _player.Bag;
    public bool Canget => _canGet;
    public Action<int> ActionChangeTImeUI;
    public Action ActionChangeUIDes;
    public Action ActionChangeQuantityCreate;
    public Action ActionChaneButtonGet_Craft;
    public Action<float> ActionChageTime;
   
    #endregion
   

    private void Start()
    {
        TimeManager.Instance.RegisterTracker(this);
    }

    
    //Craf
    #region Craf
    public void Craf()
    {
        if(!ItemCrafCurrent.enoughItem) return;
        if(isCraft) return;
        foreach (var item in ItemCrafCurrent.ItemCraftSo.Ingredients)
        {
            _bag.BagController.GetItemInBagById(item.ItemSo.ID, item.quantity * _quantityCreat);
        }
        timeCraft = (ItemCrafCurrent.ItemCraftSo.timeCraf) * _quantityCreat;
        isCraft = true;
        _itemCrafted =  FactoryItem.CreateItem( ItemCrafCurrent.ItemCraftSo.itemCrafted, _quantityCreat);
        OnStateChangeDes();
    }
    private void CrafrEnd()
    {
        isCraft = false;
        _canGet = true;
        OnStateChangeButton_Craft_Get();
    }
    public void CheckItemCraft( int index)
    {
        ItemCraf itemCraf = _listItemCrafs[index];
        foreach (var meterial in itemCraf.ItemCraftSo.Ingredients)
        {
            string idmete = meterial.ItemSo.ID;
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
    
    //Controller In Craf
    #region Controller
    private void GetMaxquantityCreate()
    {
        var number = Int32.MaxValue;
        foreach (var item in ItemCrafCurrent.ItemCraftSo.Ingredients)
        {
            var iteminBag = _bag.CountItem(item.ItemSo.ID);
            if (iteminBag / item.quantity < number)
            {
                number = iteminBag / item.quantity;
            }
        }
        _maxQuantityCreate = number;
    }
    public void GetItemCrafIntoBag()
    {
        _player.Bag.AddItem(_itemCrafted, _quantityCreat);
        _canGet = false;
        setupBegin();
    }
    public void ChangeActive(int index)
    {
        if(isCraft) return;
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
        if(isCraft) return;
        var quantityadd = _quantityCreat + 1;
        _quantityCreat = _quantityCreat >= _maxQuantityCreate ? _maxQuantityCreate : quantityadd;
        OnStateChangeUIQuantity();
    }
    public void PreviousQuantityCreate()
    {
        if(isCraft) return;
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
    private void setupBegin()
    {
        ChangeActive(0);
        CheckAllItem();
       
    }
    #endregion
    public void InterRac(PlayerManager playerManager)
    {
        _player = playerManager;
        _uiCraft.ToggleUICraf();
        setupBegin();
    }
    public void CLockUpdate(GameTime gameTime)
    {
        if(!isCraft) return;
        if (timeCraft <= 0)
        {
            CrafrEnd();
            return;
        }
        ActionChageTime?.Invoke(timeCraft);
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
