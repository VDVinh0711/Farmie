
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Farm.Scene
{
    public class Fade : MonoBehaviour
    {
        [SerializeField] private Transform _loadingSCreen;
        [SerializeField] private Slider _barloadingScreen;
        [Header("Fake LoadingScene")] 
        [SerializeField]  public  float timetoLoad = 4.0f;
        private void Awake()
        {
            _loadingSCreen = transform.GetChild(0);
            _barloadingScreen = _loadingSCreen.gameObject.GetComponentInChildren<Slider>(); 
        }

        public void SetValueBar(float value)
        {
            _barloadingScreen.value = value;
        }
        public void HideLoadingScene()
        {
            _loadingSCreen.gameObject.SetActive(false);
        }
        public void ShowLoadingScene()
        {
            _loadingSCreen.gameObject.SetActive(true);
        }
        public void TestLoadScene()
        {
            _barloadingScreen.maxValue = 100;
            _barloadingScreen.value = 0;
            StartCoroutine(runLoadingScene());
        }
        IEnumerator runLoadingScene()
        {
            int i = 0;
            while (i<=100)
            {
                yield return new WaitForSeconds(0.04f);
                _barloadingScreen.value = i;
                i++;
            }
        }
    }
}

