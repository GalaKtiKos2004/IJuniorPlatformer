using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerAnimator : MonoBehaviour
{
    const string SpeedParametr = "Speed";

    private Animator _animator;
    private PlayerMover _mover;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _mover.Moved += SetSpeed;
    }

    private void OnDisable()
    {
        _mover.Moved -= SetSpeed;
    }

    private void SetSpeed(float speed)
    {
        _animator.SetFloat(SpeedParametr, Mathf.Abs(speed));
    }
}
