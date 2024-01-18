
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiAnimal : MonoBehaviour
{
    
    private  Animator animator;
    [SerializeField] private Animal _animal;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI textshowTime;
    [SerializeField] private UiInfor _uiInfor;
    [Header("Ui State")] 
    [SerializeField] private Transform UiHarvest;

    public UiInfor UiInfor => _uiInfor;
    private void Start()
    {
        animator =transform.GetComponent<Animator>();
        _animal = GetComponent<Animal>();
        _animal.GrowAnimal.StateChangeTime -= UpdateTime;
        _animal.GrowAnimal.StateChangeTime += UpdateTime;
      
    }
    private void LateUpdate()
    {
        _uiInfor.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public void RegisterInfor(float time)
    {
        slider.maxValue = time;
    }    
    private void Settimebar(float currentime)
    {
        slider.value = currentime;
    }
   
    private void SetTimeUI(float time)
    {
        var minuteUI =  (int) time / 60;
        var secondUI = (int) time % 60;
        if (minuteUI == 0 && secondUI == 0) return;
        secondUI--;
        if(secondUI < 0)
        {
            minuteUI--;
            secondUI = 60;
            if(minuteUI < 0)
            {
                minuteUI = 0;
                secondUI = 0;
            }      
        }
        textshowTime.text = minuteUI + ":" + secondUI;
    }
    private void UpdateTime(float time)
    {
        Settimebar(time);
        SetTimeUI(time);
        Settimebar(time);
    }
    public void ShowUIinfor()
    {
        var show = _uiInfor.gameObject.activeSelf ? false : true;
        _uiInfor.gameObject.SetActive(show);
    }

   
    public void ShowUiHarvest()
    {
        UiHarvest.gameObject.SetActive(true);
    }
    public void HideUiHarvest()
    {
        UiHarvest.gameObject.SetActive(false);
    }
 
    
}
