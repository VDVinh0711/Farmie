using System;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

public class UI_InvenyotyInShop : MonoBehaviour
{
    [SerializeField] private GameObject invenShopPrefabs;
    [SerializeField] private List<UI_InventoryInShopSlot> _slots = new List<UI_InventoryInShopSlot>();
    [SerializeField] private RectTransform _invenPanel;
    [SerializeField] private Shop _shop;
     private Bag _bag =>_shop.PlayerManager.Bag;

    

     public void RenderInvenInShop()
    {
        RefeshPanel();
        
        
        foreach (var slotinven in _bag.GetListSLotItem())
        {
            var slot = Instantiate(invenShopPrefabs, _invenPanel);
            var UISlot = slot.transform.gameObject.GetComponent<UI_InventoryInShopSlot>();
            UISlot.UpdateViewItem(slotinven);
            _slots.Add(UISlot);
        }
    }
    void RefeshPanel()
    {
        foreach (RectTransform slot in _invenPanel)
        {
            Destroy(slot.gameObject);
        }
    }
    
    
}
