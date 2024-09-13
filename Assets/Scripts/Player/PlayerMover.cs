using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(PlayerInput))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;

    public event Action <float> Moved;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(_playerInput.MoveInput * _speed, _rigidbody.velocity.y);

        Rotate(direction.x);
        Moved?.Invoke(direction.x);
        _rigidbody.velocity = direction;
    }

    private void Rotate(float direction)
    {
        Quaternion rightAngle = Quaternion.Euler(Vector3.zero);
        Quaternion leftAngle = Quaternion.Euler(0f, 180f, 0f);

        if (direction > 0)
            transform.rotation = rightAngle;
        else if (direction < 0)
            transform.rotation = leftAngle;
    }
}
