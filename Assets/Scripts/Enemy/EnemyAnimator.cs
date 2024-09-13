using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyPatroler))]
public class EnemyAnimator : MonoBehaviour
{
    private const string SpeedParametr = "Speed";

    private Animator _animator;
    private EnemyPatroler _enemyPatroler;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyPatroler = GetComponent<EnemyPatroler>();
    }

    private void OnEnable()
    {
        _enemyPatroler.Moved += SetSpeed;
    }

    private void OnDisable()
    {
        _enemyPatroler.Moved -= SetSpeed;
    }

    private void SetSpeed(float speed)
    {
        _animator.SetFloat(SpeedParametr, speed);
    }
}
