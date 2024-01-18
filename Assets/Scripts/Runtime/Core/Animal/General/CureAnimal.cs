
using InventorySystem;
using UnityEngine;

public class CureAnimal : MonoBehaviour
{
   private Animal _animal;

   private void Start()
   {
      _animal = GetComponent<Animal>();
   }

   public void Cure()
   {
      if (!_animal.IsSick)
      {
         EventManger<string>.RaiseEvent("ShowNotifycation","Vật nuôi của bạn không bị bệnh");
         return;
      }
      EquidmentObject eqidItem = BagsManager.Instance.HandItem.Item as EquidmentObject;
      if (eqidItem == null)
      {
         EventManger<string>.RaiseEvent("ShowNotifycation","Bạn phải có thuốc để chữa bệnh");
         return;
      }
      eqidItem.Used(_animal);
   }
}
