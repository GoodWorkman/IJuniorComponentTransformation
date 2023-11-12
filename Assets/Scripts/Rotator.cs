using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 30f;

    private void Start()
    {
       StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        while (gameObject.activeInHierarchy)
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);

            yield return null;
        }
    }
}