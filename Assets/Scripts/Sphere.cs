using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;

    [SerializeField] private float _speed = 8f;

    private Vector3 _startPoint;
    private Vector3 _targetPoint;

    private float _distanceFault = 0.001f;

    private void Start()
    {
        _startPoint = transform.position;
        _targetPoint = _endPoint.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _targetPoint) < _distanceFault)
        {
            _targetPoint = _targetPoint == _endPoint.position ? _startPoint : _endPoint.position;
        }
    }
}