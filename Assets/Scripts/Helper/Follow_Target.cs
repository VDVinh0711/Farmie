using System;
using UnityEngine;

namespace HelperSystem
{
    public class Follow_Target : MonoBehaviour
    {

        [SerializeField] private float _maxXlimit;
        [SerializeField] private float _maxylimit;
        [SerializeField] private float _minXlimit;
        [SerializeField] private float _minylimit;
        
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
            var posx = Math.Clamp(targetPos.position.x,_minXlimit,_maxXlimit);
            var posy = Math.Clamp(targetPos.position.y,_minylimit, _maxylimit);
            var newpos = new Vector3(posx, posy, transform.position.z);
            transform.position = Vector3.Lerp(transform.position , newpos, Time.smoothDeltaTime * powerValue);
        }
    }
}

