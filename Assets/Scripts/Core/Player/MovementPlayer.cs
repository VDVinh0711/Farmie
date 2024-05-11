
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
        private PlayerAnimation _playerAnimation;
        private void Awake()
        {
            _farmInputAction = new FarmInputAction();
            _farmInputAction.Enable();
            isMove = false;
            _playerAnimation = new PlayerAnimation(animator);
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
           transform.parent.Translate(velocity);
            _playerAnimation.SetAnimator(direction.x,direction.y,isMove);
    
        }  
      

 

     
    }
}

