
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageSetting : MonoBehaviour
{
    [SerializeField] string[] myLangs;
    private int index;
    [Header("Setting language")] 
    [SerializeField] private Button _btnvn;
    [SerializeField] private Button _btnEng;


    private void Start()
    {
        GetComponent();
        RegisterEvent();
    }

    private void GetComponent()
    {
        _btnvn = transform.GetChild(1).GetChild(0).GetComponent<Button>();
        _btnEng = transform.GetChild(1).GetChild(1).GetComponent<Button>();
    }

    private void RegisterEvent()
    {
        _btnvn.onClick.AddListener(BtnVietnamClick);
        _btnEng.onClick.AddListener(BtnEnglishCLick);
    }

    private void BtnEnglishCLick()
    {
        index = 1;
        PlayerPrefs.SetInt ("_language_index", index);
        PlayerPrefs.SetString ("_language", myLangs [index]);
        ApplyLanguageChanges ();
    }

    private void BtnVietnamClick()
    {
        index = 0;
        PlayerPrefs.SetInt ("_language_index", index);
        PlayerPrefs.SetString ("_language", myLangs [index]);
        ApplyLanguageChanges ();
    }
    void ApplyLanguageChanges ()
    {
        GameManager.Instance.GameMultiLang.currentlang = myLangs[index];
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
        
    }
}
