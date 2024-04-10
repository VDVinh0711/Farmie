
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Farm.Scene
{
    public class Fade : MonoBehaviour
    {
        [SerializeField] private Transform _loadingSCreen;
        [SerializeField] private Slider _barloadingScreen;
        [SerializeField] private Image _panelImage;
        [SerializeField] CanvasGroup _canvasGroup;

        
        
        

        public void SetActiveLoad()
        {
         //   _loadingSCreen.gameObject.SetActive(true);
            _barloadingScreen.gameObject.SetActive(true);
            _panelImage.gameObject.SetActive(true);
        }

        public void DeActiveLoad()
        {
            _barloadingScreen.gameObject.SetActive(false);
            _panelImage.gameObject.SetActive(false);
        }

        public void SetValueSlider(float valueload)
        {
            _barloadingScreen.value = valueload;
        }

        #region Fade

        public void begin()
        {
            StartCoroutine(LoadFade(2 ,false));
        }
        public void LoadEnd()
        {
            StartCoroutine(LoadFade(2,true));
        
        }
        private IEnumerator LoadFade(float duration , bool countdown)
        {
            SetActiveLoad();
            float startValue = countdown ? 1 : 0;
            float endValue = countdown ? 0 : 1;
            float time = startValue;
            while (time < duration && time >= 0)
            {
                var Start = countdown ? endValue : startValue;
                var End = countdown ? startValue : endValue;
                
                var valuerProcess = Mathf.Lerp(Start, End, time / duration);
                _canvasGroup.alpha =  valuerProcess;
                time = countdown?  time - Time.deltaTime : time+ Time.deltaTime ;
                yield return null;
            }
            _canvasGroup.alpha =   endValue;
            DeActiveLoad();
         
        }

       
        #endregion
        
        

  
       
    }
}

