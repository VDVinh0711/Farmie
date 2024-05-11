
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ItemClothesShop : MonoBehaviour,IPointerClickHandler
{
   [SerializeField] private ItemShopClothes _itemShopClothes;
   [SerializeField] public Image _imageItem;
   [SerializeField] private Image _imageActive;
   [SerializeField] private ShopClothes _shopClothes;
   [SerializeField] private int _index;
   private void Awake()
   {
      _shopClothes = FindObjectOfType<ShopClothes>();
   }

   public void DisPlay(ItemShopClothes itemShopClothes , int index)
   {
      if(itemShopClothes == null ) return;
      _index = index;
      _itemShopClothes = itemShopClothes;
      _imageActive.color = _itemShopClothes.isActive ? Color.green : Color.white;
      _imageItem.sprite = itemShopClothes.itemShopObject.Thumail;
      RegisterEventForItem(itemShopClothes);

   }

   private void DisplayActive(ItemShopClothes itemShopClothes )
   {
      _imageActive.color = itemShopClothes.isActive ? Color.green : Color.white;
   }
   private void RegisterEventForItem(ItemShopClothes itemShopClothes)
   {
      itemShopClothes.satechangeUI -= DisplayActive;
      itemShopClothes.satechangeUI += DisplayActive;
   }

   public void ActiveItem(ItemShopClothes itemShopObject)
   {
      if(itemShopObject == null ) return;
      _itemShopClothes = itemShopObject;
      _imageItem.color = Color.green;
   }
   public void DeActive()
   {
      _imageItem.color = Color.clear;
   }

   public void OnPointerClick(PointerEventData eventData)
   {
      _shopClothes.ActiveItem(_index);
   }
}
