using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _moveDistance = 10f;

    [SerializeField] private bool _isLooped;

    private void Start()
    {
        if (_isLooped == false)
        {
            StartCoroutine(MoveToDistance());
        }
        else
        {
            StartCoroutine(MoveLoop());
        }
    }

    private IEnumerator MoveLoop()
    {
        while (gameObject.activeInHierarchy)
        {
            transform.Translate(Vector3.forward * (_speed * Time.deltaTime));

            yield return null;
        }
    }

    private IEnumerator MoveToDistance()
    {
        float movedDistance = 0;

        while (movedDistance < _moveDistance)
        {
            float step = _speed * Time.deltaTime;
            
            transform.Translate(Vector3.forward * step);

            movedDistance += step;

            yield return null;
        }
    }
}