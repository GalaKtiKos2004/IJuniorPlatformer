using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    [SerializeField] private float _minPositionY = -5f;

    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (IsDeath())
            transform.position = _startPosition;
    }

    private bool IsDeath()
    {
        return transform.position.y < _minPositionY;
    }
}
