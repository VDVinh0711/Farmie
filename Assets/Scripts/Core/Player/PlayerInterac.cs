
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

          //  Vector2 worldPosCame = _playerManager.CameraPlayer.ScreenToWorldPoint(mousePosition);
            Vector2 worldPosCame = Camera.main.ScreenToWorldPoint(mousePosition);
            
            
           
            
            print(worldPosCame);
            
            Debug.DrawRay(worldPosCame,Vector2.zero);
            
            
            
            //Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            RaycastHit2D hitclick;
            hitclick = Physics2D.Raycast(worldPosCame, Vector2.zero, Mathf.Infinity);
            if (hitclick.collider == null) return;
            if (Vector3.Distance(transform.parent.position, hitclick.transform.position) > 5.0f) return;
            IInterac interac = hitclick.transform.gameObject.GetComponent<IInterac>();
            print(hitclick.transform.gameObject.name);
            if (interac == null)
            {
                print("Null inter ");
                return;
            }
            interac.InterRac(transform.parent.GetComponent<PlayerManager>());
        }
        
        void OnDrawGizmos()
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Gizmos.DrawSphere(worldPosition, 0.1f);
        }
   
    }
}

