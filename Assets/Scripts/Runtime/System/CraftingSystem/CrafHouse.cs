
using UnityEngine;

public class CrafHouse : MonoBehaviour,IInterac
{
    [SerializeField] private UI_Craft _uiCraft;

    public void InterRac()
    {
        _uiCraft.ToggleCraftingUI();
    }
}
