
using System.Collections.Generic;

using InventorySystem;

using UnityEngine;

public class UI_InvenyotyInShop : MonoBehaviour
{
    [SerializeField]
    private GameObject invenShopPrefabs;
    [SerializeField]
    private List<UI_InventoryInShopSlot> _slots = new List<UI_InventoryInShopSlot>();
    private Bag _bag;
    [SerializeField]
    private RectTransform _invenPanel;

    
    public void RenderInvenInShop()
    {
        RefeshPanel();
        foreach (var slotinven in Bag.Instance.GetListSLotItem())
        {
            var slot = Instantiate(invenShopPrefabs, _invenPanel);
            var UISlot = slot.transform.gameObject.GetComponent<UI_InventoryInShopSlot>();
            UISlot.RenderItem(slotinven);
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
