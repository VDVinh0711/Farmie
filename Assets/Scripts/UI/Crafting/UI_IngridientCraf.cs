using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UI_IngridientCraf :MonoBehaviour
{
   [SerializeField] private Image _image;
   [SerializeField] private TextMeshProUGUI _quantityText;
   [SerializeField] private Image _imageOverlay;
   
   public void Display(Item_SO itemSo , int quantity , int quantityBag)
   {
      if(itemSo == null) return;
      var hasoverLay = quantity > quantityBag;
      _imageOverlay.enabled = hasoverLay;
      _image.sprite = itemSo.UIinInven;
      _quantityText.SetText(quantity+"/" +  quantityBag);
   }


}
