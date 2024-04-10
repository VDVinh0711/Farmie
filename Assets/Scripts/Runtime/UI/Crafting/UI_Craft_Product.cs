
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Craft_Product :MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _quantityText;
   [SerializeField] private CrafSystem _crafSystem;
   [SerializeField] private Image _image;
   [SerializeField] private Image Overlay;
   public  void DisPlay(Item_SO itemSo, int quantity)
   {
       _image.enabled = itemSo != null;
       _quantityText.SetText("");
       Overlay.enabled = _crafSystem.IsCraf; 
       if(itemSo == null) return;
       _image.sprite = itemSo.UIinInven;
        string quantitytext = quantity > 1 ? quantity+"" : "";
         _quantityText.SetText(quantitytext);
   }

   

   public void SetValueOverLay(float value)
   {
       Overlay.fillAmount = value;
   }
}
