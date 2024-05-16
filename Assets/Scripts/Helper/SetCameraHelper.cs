using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraHelper : MonoBehaviour
{
   [SerializeField] private Canvas _canvas;


   private void Awake()
   {
      SetCameraForCanvas();
   }

   private void SetCameraForCanvas()
   {
      _canvas.worldCamera = Camera.main;
   }
}
