using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private GroundDetector _groundDetector;

    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        if (_playerInput.JumpInput)
            TryJump();
    }

    private void TryJump()
    {
        if (IsGrounded())
        {
            _rigidbody.AddForce(new Vector2(0f, _force), ForceMode2D.Impulse);
        }

    }

    private bool IsGrounded()
    {
        return _groundDetector.IsGrounded(transform);
    }
}