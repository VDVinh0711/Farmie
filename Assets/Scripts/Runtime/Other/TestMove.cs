using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
   [SerializeField] private Transform Target;
   public float movespeed = 0.1f;
   [SerializeField] private Vector2 direction;


   private void FixedUpdate()
   {
     
      direction = Target.position - transform.position.normalized;
      /* transform.position =(Vector2) Vector3.Lerp(transform.position, _postoeat.position, moveSpeed * Time.smoothDeltaTime);*/
      transform.Translate((Vector2) direction  * movespeed * Time.deltaTime); 
   }
}
