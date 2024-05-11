
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

using SavingSystem;

namespace Farm.Scene
{
    public enum Location
    {
        FarmScene,
        TownScene,
    }
   
    public class Potal : MonoBehaviour
    {
        [SerializeField] public Location _scenetoLoad;
        [SerializeField] public Transform _startPoint;
        private AsyncOperation sceneAsync;
        /*private void OnTriggerEnter2D(Collider2D other)
        {
            StartCoroutine(OnLoadSceneasyc(_scenetoLoad.ToString()));
        }
        IEnumerator OnLoadSceneasyc(string nameScene)
        {
            var savingWraper = FindObjectOfType<SaveWraper>();
            savingWraper.Save();
            var currentscene = SceneManager.GetActiveScene();
            Fade fade = FindObjectOfType<Fade>();
            DontDestroyOnLoad(gameObject);
            yield return new WaitForSeconds(fade.timetoLoad);
            var aycScene = SceneManager.LoadSceneAsync(nameScene, LoadSceneMode.Additive);
            while(!aycScene.isDone)
            {
                yield return null;
            }
            SceneManager.UnloadSceneAsync(currentscene);
            UpdatePlayer();
            // savingWraper.Load();
            Destroy(gameObject);
        
        }*/
        public void UpdatePlayer()
        {
            var player = getPlayer();
            var charactercontroller = player.GetComponent<CharacterController>();
            charactercontroller.enabled = false;
            var potal = getOtherTotal();
            player.position = potal._startPoint.position;
            charactercontroller.enabled = true;
            
        }
        public Potal getOtherTotal()
        {
            foreach (var potal in FindObjectsOfType<Potal>())
            {
                if( potal._scenetoLoad.ToString() == SceneManager.GetActiveScene().ToString()) continue;
                if(potal == this) continue;
                return potal;
            }
            return null;
        }
        private Transform getPlayer()
        {
            var currentscene = SceneManager.GetActiveScene();
            var characterControllers = FindObjectsOfType<CharacterController>();
            foreach (var characterController in characterControllers)
            {
                if(!(currentscene  == characterController.gameObject.scene)) continue;
                return characterController.transform;
            }

            return null;
        }
        
        
    }
}

