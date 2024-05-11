using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class Cloud : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _Distance;
    [SerializeField] private Vector2 StartPoint;
    private void OnEnable()
    {
        StartPoint = this.transform.position;
    }
    private void Update()
    {

        transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
        if (Vector3.Distance(StartPoint, this.transform.position) >= _Distance)
        {
            PollingObject.Instance.AddPooling(this.transform);
        }
    }
}
