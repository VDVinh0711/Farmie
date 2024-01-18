
using UnityEngine;


namespace Player
{
    public class PlayerInterac : MonoBehaviour
    {
    
        private void Update()
        {
      
            InteracClick();
        }
        private void  InteracClick()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            Vector2 mousePosition = Input.mousePosition;
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            RaycastHit2D hitclick;
            hitclick = Physics2D.Raycast(worldPosition, Vector2.zero, Mathf.Infinity);
            if (hitclick.collider == null) return;
            if (Vector3.Distance(transform.parent.position, hitclick.transform.position) > 5.0f) return;
            IInterac interac = hitclick.transform.gameObject.GetComponent<IInterac>();
            if (interac == null)
            {
                print("Null inter ");
                return;
            }
            interac.InterRac();
        }
        
   
    }
}

