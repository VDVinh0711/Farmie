
using TMPro;
using UnityEngine;

public class UI_Craft_DesScription : MonoBehaviour
{
    [SerializeField] private CrafSystem _crafSystem;
    [SerializeField] private Transform _ingredientPre;
    [SerializeField] private Transform _holder;
    [SerializeField] private TextMeshProUGUI _textDes;
    public void ShowDesScriptTion(ItemCraf itemCraf)
    {
        SpawnReviewIngridient(itemCraf);
        _textDes.SetText(GameMultiLang.GetTraduction(itemCraf.ItemCraftSo.keyDes));
    }
    
    private void SpawnReviewIngridient(ItemCraf itemCraf)
    {
        RefeshOBJ();
        foreach (var materialItem in itemCraf.ItemCraftSo.Ingredients)
        {
            var materialSpawn = Instantiate(_ingredientPre, _holder);
            var ui_meteria = materialSpawn.gameObject.GetComponent<UI_IngridientCraf>();
            var quantityitemBag = _crafSystem.PlayerManager.Bag.CountItem(materialItem.ItemSo.ID);
            ui_meteria.Display(materialItem.ItemSo, materialItem.quantity ,quantityitemBag);
        }
    }

    private void RefeshOBJ()
    {
        foreach (var uislot in _holder.GetComponentsInChildren<UI_IngridientCraf>())
        {
            Destroy(uislot.gameObject);
        }
    }
}
