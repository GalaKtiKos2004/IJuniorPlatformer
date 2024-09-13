using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _delay = 5f;

    private float _currentSpeed;

    private void Start()
    {
        _currentSpeed = _speed;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PatrolBorder border))
            StartCoroutine(CountPatrolDelay(_delay));
            
    }

    private IEnumerator CountPatrolDelay(float delay)
    {
        _currentSpeed = 0;

        yield return new WaitForSeconds(delay);

        transform.Rotate(0, 180, 0);
        _currentSpeed = _speed;
    }
}
