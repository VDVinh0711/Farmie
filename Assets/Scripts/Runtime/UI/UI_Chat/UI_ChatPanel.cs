using System;
using System.Collections;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI_ChatPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField _txtInput;
    [SerializeField] private Button _btnSend;
    [SerializeField] private RectTransform _showPanel;
    [SerializeField] private TextMeshProUGUI _txtshow;
    [SerializeField] private RectTransform _panelInput;
    [SerializeField] private FarmInputAction _farmInputAction;


    private void Start()
    {
        _farmInputAction = new FarmInputAction();
        _farmInputAction.Enable();
        _farmInputAction.InteracPlayer.Enterclick.performed += Enter;
    }

    private void Enter(InputAction.CallbackContext obj)
    {
        SendText();
    }

    public void SendText()
    {
        if(_txtInput.text.ToString().Trim().Length == 0) return;
        var player = PlayerController.Instance.gameObject.transform;
        _showPanel.position = new Vector3(player.position.x+0.5f,player.position.y + 1f,player.position.z);
        HidePanle();
        _showPanel.gameObject.SetActive(true);
        _txtshow.SetText(_txtInput.text.ToString());
        StartCoroutine(WaitcloseText());
    }

    public void UIChatTroggle()
    {
        if (_panelInput.gameObject.activeSelf)
        {
            HidePanle();
            return;
        }

        ShowPanel();
    }

    IEnumerator WaitcloseText()
    {
        var check = _showPanel.gameObject.activeSelf;
        while (check)
        {
            yield return new WaitForSeconds(5.0f);
            _showPanel.gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        if(!_showPanel.gameObject.activeSelf) return;
        var player = PlayerController.Instance.gameObject.transform;
        _showPanel.position = new Vector3(player.position.x+0.5f,player.position.y + 1f,player.position.z);
    }

    private void ShowPanel()
    {
        _panelInput.gameObject.SetActive(true);
        _txtInput.Select();
        _txtInput.text = "";
        _farmInputAction.InteracPlayer.Enterclick.performed += Enter;
    }

    private void HidePanle()
    {
        _panelInput.gameObject.SetActive(false);
        _farmInputAction.InteracPlayer.Enterclick.performed -= Enter;
    }
}
