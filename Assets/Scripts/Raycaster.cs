using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private float _rayLength = 0.1f;

    public bool IsGrounded(Transform checkPoint)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPoint.position, Vector2.down, _rayLength);

        if (hit)
        {
            Debug.Log(hit.collider);
            if (hit.collider.TryGetComponent(out Platform platform))
                return true;
        }

        return false;
    }
}
