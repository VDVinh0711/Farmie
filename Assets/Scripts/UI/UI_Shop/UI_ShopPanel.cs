using System.Collections.Generic;
using UnityEngine;
namespace UI.UI_Shop
{
    public class UI_ShopPanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject _slotPrefabs;
        private List<UI_ItemInShopSlot> _slots = new List<UI_ItemInShopSlot>();
        [SerializeField]
        private Transform _shopPanel;
        private List<ItemShopObject> _itemdatas;
        public void InstantiateShop(List<ItemShopObject> itemdata)
        {
            _itemdatas = new List<ItemShopObject>(itemdata);
            foreach (var slot in _itemdatas)
            {
                var newShopSlot = Instantiate(_slotPrefabs, _shopPanel);
                var scriptUIshop = newShopSlot.gameObject.GetComponent<UI_ItemInShopSlot>();
                scriptUIshop.DisPlay(slot);
                itemdata.Remove(slot);
                _slots.Add(scriptUIshop);
            }
        }
        public void ShowShopPanel()
        {
            var show = gameObject.activeSelf? false : true;
            Debug.Log("Shop"+show);
            gameObject.SetActive(show);
        }
    }
}