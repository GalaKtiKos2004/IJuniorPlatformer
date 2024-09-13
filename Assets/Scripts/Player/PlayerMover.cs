using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw(Horizontal), 0f, 0f);

        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
    }
}
