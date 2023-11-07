using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    [SerializeField] private float _minimalScale = 1f;
    [SerializeField] private float _maximalScale = 3f;
    [SerializeField] private float _pulseSpeed = 2f;

    private Vector3 _originScale;

    private float _originalYPosition;

    private void Start()
    {
        _originScale = transform.localScale;

        _originalYPosition = transform.position.y;
    }

    private void Update()
    {
        Pulse();
    }

    private void Pulse()
    {
        float pingPongLenght = 1f;

        float pulseTime = Mathf.PingPong(Time.time * _pulseSpeed, pingPongLenght);

        float currentScaleFactor = Mathf.Lerp(_minimalScale, _maximalScale, pulseTime);

        transform.localScale = _originScale * currentScaleFactor;

        CorrectPosition();
    }

    private void CorrectPosition()
    {
        float scaleChange = transform.localScale.y / _originScale.y;

        float newYPosition = _originalYPosition + _originScale.y * (scaleChange - _minimalScale);

        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
}