using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  Player
{
    public class PlayerAnimation 
    {
        private Animator _animator;
        public PlayerAnimation(Animator animator)
        {
            _animator = animator;
        }
        public void SetAnimator(float horizontal, float vertical,bool ismove)
        {
           
           _animator.SetBool("moving",ismove);
            
            _animator.SetFloat("moveX", horizontal);
            _animator.SetFloat("moveY", vertical);
          
            if (horizontal == 0 && vertical == 0) return;
            _animator.SetFloat("LastMoveX", horizontal);
            _animator.SetFloat("LastMoveY", vertical);
        }
    }

}
