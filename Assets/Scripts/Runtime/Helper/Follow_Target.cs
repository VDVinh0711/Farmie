using System;
using UnityEngine;

namespace HelperSystem
{
    public class Follow_Target : MonoBehaviour
    {
        [SerializeField] private Transform targetPos;
        [SerializeField] private float powerValue = 1.0f;

        public Transform TargetPos
        {
            get => targetPos;
            set
            {
                targetPos = value;
            }
        }
        private  void LateUpdate()
        {
            MoveTarget();
        }
        void MoveTarget()
        {
            if(targetPos ==null) return;
            var campos = Camera.main;
            var posx = Math.Clamp(targetPos.position.x,0,float.MaxValue);
            var posy = Math.Clamp(targetPos.position.y, -0.1f, 0.1f);
            var newpos = new Vector3(posx, posy, transform.position.z);
            transform.position = Vector3.Lerp(transform.position , newpos, Time.smoothDeltaTime * powerValue);
        }
    }
}

