using System;
using InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComfirmQuantity : Singleton<ComfirmQuantity>
{
    [SerializeField] private TextMeshProUGUI _tile;
    [SerializeField] private TMP_InputField _inputQuantity;
    [SerializeField] private Button _btnCancle;
    [SerializeField] private Button _btnOk;
    [SerializeField] private RectTransform panel;

  

    private void Start()
    {
       
        RegisterEvent();
    }

    private void RegisterEvent()
    {
        _btnCancle.onClick.AddListener(Hide);
        _inputQuantity.onValidateInput = (string text, int charIndex, char addedChar) =>
        {
            if (text.Length >= 2) return addedChar = '\0';
            return ValidateChar("0123456789", addedChar);
        };
    }

    public void Show( Action<int> action , string title)
    {
        _tile.SetText(title);
        _inputQuantity.text = "";
        _inputQuantity.Select();
        panel.gameObject.SetActive(true);
        _btnOk.onClick.RemoveAllListeners();
        _btnOk.onClick.AddListener(() =>
        {
            action?.Invoke(int.Parse(_inputQuantity.text));
        });
        _btnOk.onClick.AddListener(Hide);
    }
    public void Hide()
    {
        panel.gameObject.SetActive(false);
    }
    private char ValidateChar(string validateCharacter, char addedChar)
    {
        if (validateCharacter.Contains(addedChar))
        {
            //valid
            return addedChar;
        }
            //Invalid
        return '\0';
    }
}
