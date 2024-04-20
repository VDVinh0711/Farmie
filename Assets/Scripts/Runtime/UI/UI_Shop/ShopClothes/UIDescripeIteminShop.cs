
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDescripeIteminShop : MonoBehaviour
{


   [SerializeField] private ShopClothes _shopClothes;
   [Header("Text")]
   [SerializeField] private TextMeshProUGUI _textNameItem;
   [SerializeField] private TextMeshProUGUI _textPriceItem;
   [SerializeField] private TextMeshProUGUI _textDesItem;

   [Header("Preview Player")]
   [SerializeField] private ModelPreViewPlayer _modelPreViewPlayer;
   [Header("Button Buy")]
   [SerializeField] private Button _buttonBuy;
   
   
   private void Awake()
   {
      _buttonBuy.onClick.AddListener(ActionButtoonBuy);
   }
   public void SetTextShow(Itemshop itemShopObject)
   {
      if(itemShopObject == null) return;
      _textNameItem.SetText("Name" + itemShopObject.name);
      _textPriceItem.SetText("Price : " + itemShopObject.Price);
      _textDesItem.SetText(itemShopObject.Descri);
   }
   private void ActionButtoonBuy()
   {
      if(_shopClothes == null) return;
      _shopClothes.PurChareClothes();
   }
   public void SetModelPreViewBegin()
   {
      var modelManager =_shopClothes.PlayerManager.ModelPlayerManager;
      if(modelManager == null) return;
      foreach (var clothes in modelManager.ListClothesPlayer)
      {
         _modelPreViewPlayer.SetClothesPlayer(clothes.type, clothes.itemClothes.Item.ItemInfor as ClothesItem_SO);
      }
      foreach (var part in modelManager.ListPartPlayers)
      {
         _modelPreViewPlayer.SetPartPlayer(part.type, part.partPlayer);
      }
   }
   public void SetModelPeView(Itemshop itemShopObject)
   {
      SetModelPreViewBegin();
      if(itemShopObject == null) return;
      var itemclothes = itemShopObject.itemdata as ClothesItem_SO;
      if(itemclothes == null) return;
      _modelPreViewPlayer.SetClothesPlayer(itemclothes.Type , itemclothes);
   }
   
}
