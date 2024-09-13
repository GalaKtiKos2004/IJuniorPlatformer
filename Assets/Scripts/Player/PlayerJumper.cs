using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private GroundDetector _groundDetector;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
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