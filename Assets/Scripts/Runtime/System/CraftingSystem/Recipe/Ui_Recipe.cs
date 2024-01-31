using System;

using System.Collections.Generic;
using UnityEngine;

public class Ui_Recipe : MonoBehaviour
{
   [SerializeField] private Transform _recipePre;
   [SerializeField] private Recipe _recipe;
   [SerializeField] private List<UI_RecipeSlot> _uiRecipeSlots;
   [SerializeField] private Transform _rootSpawn;


   private void Start()
   {
      _recipe = new Recipe();
      IntantiateSlotRecipe();
   }

   private void IntantiateSlotRecipe()
   {
      foreach (var recipe in _recipe.ListRecipe)
      {
         var SlotSpawn = Instantiate(_recipePre, _rootSpawn).GetComponent<UI_RecipeSlot>();
        SlotSpawn.Display(recipe);
         _uiRecipeSlots.Add(SlotSpawn);
      }
   }

   public void TroggleUIRecipe()
   {
      if (gameObject.activeSelf)
      {
         gameObject.SetActive(false);
         return;
      }
      gameObject.SetActive(true);
   }
   
   
}
