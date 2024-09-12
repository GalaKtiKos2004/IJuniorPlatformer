using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;
    [SerializeField] private float _speed;
    [SerializeField] private float _duration;

    private Rigidbody _rigidbody;

    private bool _isJumping = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _isJumping == false)
        {
            StartCoroutine(JumpByTime(_duration, _speed));
            _isJumping = true;
        }

    }

    private IEnumerator JumpByTime(float duration, float speed)
    {
        float expiredSeconds = 0f;
        float progress = 0f;
        float maxProgress = 1f;

        while (progress < maxProgress)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duration;

            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, speed * _yAnimation.Evaluate(progress), 0f); 

            yield return null;
        }

        _isJumping = false;
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, 0f);
    }
}
