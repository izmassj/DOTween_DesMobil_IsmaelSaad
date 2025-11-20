using DG.Tweening;
using UnityEngine;

public class ObjectAController : MonoBehaviour
{
    private Vector3 originalPos = Vector3.zero;

    private bool isAnimationFinished = false;
    private bool isAnimationPlaying = false;

    private void Awake()
    {
        originalPos = transform.position;
    }

    public void RunAnimation()
    {
        if (isAnimationPlaying)
            return;

        isAnimationPlaying = true;
        isAnimationFinished = false;

        transform.DOJump(new Vector3(-10, 3, 5), 3f, 1, 1.5f)
                 .OnComplete(AnimationFinished);
    }

    public void ResetAnimation()
    {
        if (isAnimationPlaying)
            return;

        isAnimationFinished = false;
        transform.position = originalPos;
    }

    private void AnimationFinished()
    {
        isAnimationPlaying = false;
        isAnimationFinished = true;
    }
}
