using UnityEngine;

public class CollisionIgnore : MonoBehaviour
{
    [SerializeField] private Collider2D[] _ignoreColliders;

    private void Awake()
    {
        Collider2D collider = GetComponent<Collider2D>();

        foreach (Collider2D ignoreCollider in _ignoreColliders)
            Physics2D.IgnoreCollision(collider, ignoreCollider);
    }
}
