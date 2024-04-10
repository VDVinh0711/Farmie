
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Test : MonoBehaviour
{


        [SerializeField] private List<Item_SO> itemadd = new();
        [SerializeField] private PlayerManager _playerManager;
        [SerializeField] private int quantityRequest;
        [SerializeField] private CrafSystem _crafSystem;
        [SerializeField] private Item_SO _itemcout;
        public void TestAddbag()
        {
            foreach (var item in itemadd)
            {
                _playerManager.Bag.AddItem(item, 3);
            }

        }
      

        public void testCheckCraft()
        {
            Debug.Log(_playerManager.Bag.CountItem(_itemcout.ID));
        }

        public void testGet()
        {
            _playerManager.Bag.BagController.GetItemInBagById(_itemcout.ID, 3);
        }
}
