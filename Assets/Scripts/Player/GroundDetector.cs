using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _rayLength = 0.75f;

    private bool _onGround = false;

    public bool IsGrounded(Transform checkPoint)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPoint.position, Vector2.down, _rayLength);

        if (hit && _onGround)
        {
            if (hit.collider.TryGetComponent(out Platform platform))
                return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Platform platform))
            _onGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Platform platform))
            _onGround = false;
    }
}
