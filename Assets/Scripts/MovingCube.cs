using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 2f;
    [SerializeField] private float _rotationSpeed = 20f;
    [SerializeField] private float _scaleSpeed = 2f;

    [SerializeField] private float _minimalScale = 1f;
    [SerializeField] private float _maximalScale = 3f;

    private Vector3 _originalScale;

    private float _originalYPosition;
    private float _pingPongLenght = 1f;

    private void Start()
    {
        _originalScale = transform.localScale;

        _originalYPosition = transform.position.y;
    }

    private void Update()
    {
        Move();
        Rotate();
        Pulse();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * (_movingSpeed * Time.deltaTime));
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }

    private void Pulse()
    {
        float pulseTime = Mathf.PingPong(Time.time * _scaleSpeed, _pingPongLenght);

        float currentScaleFactor = Mathf.Lerp(_minimalScale, _maximalScale, pulseTime);

        transform.localScale = _originalScale * currentScaleFactor;

        CorrectYPosition();
    }

    private void CorrectYPosition()
    {
        float repairInHalfScale = 2f;

        float scaleChange = transform.localScale.y / _originalScale.y;

        float newYPosition = _originalYPosition + _originalScale.y * (scaleChange - _minimalScale) / repairInHalfScale;

        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
}