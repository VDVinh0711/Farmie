using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ComfirmManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _contenttxt;
    [SerializeField] private Button _buttonAccept;
    [SerializeField] private Button _buttonCancle;
    [SerializeField] private RectTransform _root;
    public static ComfirmManager Intance;
    protected  void Awake()
    {
        Intance = this;
    }
    void Start()
    {
        _root = transform.GetChild(0).GetComponent<RectTransform>();
        _contenttxt = _root.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _buttonAccept = _root.transform.GetChild(1).GetComponent<Button>();
        _buttonCancle = _root.transform.GetChild(2).GetComponent<Button>();
    }
    public void Show(string content, IActionAccept actionAccept)
    {
        _root.gameObject.SetActive(true);
        _buttonAccept.onClick.RemoveAllListeners();
        _buttonCancle.onClick.RemoveAllListeners();
        _contenttxt.SetText(content);
        _buttonAccept.onClick.AddListener(actionAccept.ActionAccept);
        _buttonCancle.onClick.AddListener(hidepanle);
        _buttonAccept.onClick.AddListener(hidepanle);
       
    }
    private void hidepanle()
    {
        _root.gameObject.SetActive(false);
       ;
    }

  
}
