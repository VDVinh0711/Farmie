
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class MoveAnimal : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.1f;
    private Vector2 roamingPositon;
    private Quaternion leftRotation = Quaternion.Euler(0, 180, 0);
    private Quaternion rightRotation = Quaternion.Euler(0, 0, 0);
    private Rigidbody2D animalRb;
    public UnityAction Move;
    public bool isMove = false;
    [SerializeField]   private Transform _postoeat;
    [SerializeField] Vector2 direction; 
    public Vector2 Direction => direction;
    public Transform Postoeat => _postoeat;
    
    public virtual void Start()
    {
      
        animalRb = GetComponent<Rigidbody2D>();
        SetNewTargetPosion(GetRandomDir());
        Move = MoveRandomDir;
        _postoeat = transform.GetComponentInParent<Stable>().Trough.gameObject.transform;
    }
    
    private void MoveRandomDir()
    {
        if(!isMove) return;
        var newpos = Vector3.Lerp(transform.position, roamingPositon, moveSpeed * Time.smoothDeltaTime);
        transform.position =new Vector2(newpos.x,newpos.y) ;
        ChangeTargetPos();
    }

    private void MoveFollowPos()
    {
        if(!isMove ) return;
        direction = (_postoeat.position - transform.position).normalized;
       /* transform.position =(Vector2) Vector3.Lerp(transform.position, _postoeat.position, moveSpeed * Time.smoothDeltaTime);*/
       transform.Translate((Vector2) direction  * moveSpeed * Time.deltaTime); 
    }
   
    private void SetNewTargetPosion(Vector2 dir)
    {
         roamingPositon = (Vector2)transform.position + dir * Random.Range(1.5f,2f);
         direction =dir;
    }
    Vector2 GetRandomDir()
    {   
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
     void ChangeTargetPos()
    {
        if (Vector3.Distance(transform.position, roamingPositon) >= 1) return;
        SetNewTargetPosion(GetRandomDir());
    }
    
    public void SetRotation()
    {
        transform.rotation = direction.x > 0 ? rightRotation : leftRotation;
    }

    public void ResetRotation()
    {
        transform.rotation =  Quaternion.Euler(0, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Barie")) return;
        SetNewTargetPosion( GetRandomDir());
    }

    public void RegisterMovetarget()
    {
        UnregisterMoveTarget();
        Move += MoveFollowPos;
    }

    public void RegisterMoveRandom()
    {
        Move += MoveRandomDir;
    }

    public void UnregisterMoveTarget()
    {
        UnregisterMoveRand();
        Move -= MoveFollowPos;
    }

    public void UnregisterMoveRand()
    {
        Move -= MoveRandomDir;
    }

    public bool checkIncome()
    {
        if (Vector3.Distance(transform.position, _postoeat.position) <= 1)
        {
            isMove = false;
            return true;
        }

        return false;
    }
    
   

    
    
    
    
   

   
}
