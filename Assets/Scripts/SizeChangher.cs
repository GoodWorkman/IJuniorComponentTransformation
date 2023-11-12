using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChangher : MonoBehaviour
{
   [SerializeField] private float _pulseSpeed = 2f;
   [SerializeField] private float _minimalScale = 1f;
   [SerializeField] private float _maximalScale = 3f;
   [SerializeField] private float _liftReductionRatio = 2f;
   
   private Vector3 _originalScale;
   
   private float _originalYPosition;

   private void Start()
   {
      _originalScale = transform.localScale;

      _originalYPosition = transform.position.y;

      StartCoroutine(Pulsation());
   }

   private IEnumerator Pulsation()
   {
      float pingPongLenght = 1f;

      while (gameObject.activeInHierarchy)
      {
         float pulseTime = Mathf.PingPong(Time.time * _pulseSpeed, pingPongLenght);

         float currentScaleFactor = Mathf.Lerp(_minimalScale, _maximalScale, pulseTime);

         transform.localScale = _originalScale * currentScaleFactor;
         
         CorrectPosition();

         yield return null;
      }
   }

   private void CorrectPosition()
   {
      float scaleChange = transform.localScale.y / _originalScale.y;

      float newYPosition = _originalYPosition + _originalScale.y * (scaleChange - _minimalScale) / _liftReductionRatio;

      transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
   }
}