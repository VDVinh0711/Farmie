
using UnityEngine;


namespace Player
{
    public class PlayerInterac : MonoBehaviour
    {


        [SerializeField] private PlayerManager _playerManager;
        private void Update()
        {
            InteracClick();
        }
        private void  InteracClick()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            Vector2 mousePosition = Input.mousePosition;

            Vector2 worldPosCame = _playerManager.CameraPlayer.ScreenToWorldPoint(mousePosition);
            
            //Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            RaycastHit2D hitclick;
            hitclick = Physics2D.Raycast(worldPosCame, Vector2.zero, Mathf.Infinity);
            if (hitclick.collider == null) return;
            print(hitclick.transform.gameObject.name);
            if (Vector3.Distance(transform.parent.position, hitclick.transform.position) > 5.0f) return;
            IInterac interac = hitclick.transform.gameObject.GetComponent<IInterac>();
            if (interac == null)
            {
                print("Null inter ");
                return;
            }
            interac.InterRac(transform.parent.GetComponent<PlayerManager>());
        }
        
   
    }
}

