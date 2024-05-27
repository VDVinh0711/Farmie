using System;
using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;


namespace  Test
{
    public class AddItemInBag : MonoBehaviour
    {
        public Item_SO itemAdd;

        public Bag Bag;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                AddtoBag();
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                GetItemByID();
            }
        }

        public void AddtoBag()
        {
            Bag.AddItem(FactoryItem.CreateItem(itemAdd, 4));
        }

        public void GetItemByID()
        {
            Bag.BagController.GetItemInBagById(itemAdd.ID,2);
        }


    }
}
