using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    [SerializeField] private float _minPositionY = -5f;

    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DeathTrigger trigger))
            transform.position = _startPosition;
    }
}
