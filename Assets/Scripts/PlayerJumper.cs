using System.Collections;
using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;
    [SerializeField] private float _height;
    [SerializeField] private float _duration;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(JumpByTime(_duration, _height));
        }

    }

    private IEnumerator JumpByTime(float duration, float height)
    {
        float expiredSeconds = 0f;
        float progress = 0f;
        float maxProgress = 1f;

        Vector3 startPosition = transform.position;

        while (progress < maxProgress)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duration;

            transform.position = startPosition + new Vector3(0f, _yAnimation.Evaluate(progress) * height, 0f);
            
            yield return null;
        }
    }
}
