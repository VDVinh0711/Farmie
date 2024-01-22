
using System;
using UnityEngine.InputSystem;
using UnityEngine;


namespace Player
{
    public class MovementPlayer : MonoBehaviour
    {
        public bool isMove = false;
        [SerializeField] private Animator animator;
        private FarmInputAction _farmInputAction;
        public float moveSpeed;
        private void Awake()
        {
            _farmInputAction = new FarmInputAction();
            _farmInputAction.Enable();
            isMove = false;
        }
    
        void Update()
        {
            Move();
        }
        void Move()
        {
            Vector2 direction =  _farmInputAction.Player.Movement.ReadValue<Vector2>();
            isMove = (direction.x != 0 || direction.y != 0) ? true : false;
            Vector2 velocity = moveSpeed * Time.deltaTime * direction;
           // transform.parent.Translate(velocity);
           transform.parent.Translate(velocity);
            setAnimator(direction.x, direction.y,velocity);
            FlipPlayer(direction.x);
    
        }  
        void setAnimator(float horizontal , float vertical,Vector2 velocity)
        {
            animator.SetFloat("horizontal" , horizontal);
            animator.SetFloat("vertical", vertical);
            animator.SetFloat("Speed", velocity.magnitude);  
        }

        void FlipPlayer(float horizontal)
        {
            SpriteRenderer renderer = transform.parent.gameObject.GetComponentInChildren<SpriteRenderer>();
            if (horizontal >= 0)
            {
                renderer.flipX = true;
            }
            else
            {
                renderer.flipX = false;
            }
        }

     
    }
}

