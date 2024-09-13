using System;
using System.Collections;
using UnityEngine;

public class EnemyPatroler : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _delay = 5f;

    private float _currentSpeed;

    public event Action<float> Moved;

    private void Start()
    {
        _currentSpeed = _speed;
    }

    private void Update()
    {
        Moved?.Invoke(_currentSpeed);
        transform.Translate(Vector3.left * _currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PatrolBorder border))
            StartCoroutine(CountPatrolDelay(_delay));
            
    }

    private IEnumerator CountPatrolDelay(float delay)
    {
        Vector3 rotation = new Vector3(0f, 180f, 0f);

        _currentSpeed = 0;

        yield return new WaitForSeconds(delay);

        transform.Rotate(rotation);
        _currentSpeed = _speed;
    }
}
