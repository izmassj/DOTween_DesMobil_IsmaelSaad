using DG.Tweening;
using UnityEngine;

public class ObjectAController : MonoBehaviour
{
    private Vector3 originalPos = Vector3.zero;
    private bool isAnimationFinished = false;

    private void Awake()
    {
        originalPos = transform.position;
    }

    public void RunAnimation()
    {
        if (!isAnimationFinished)
        {
            // un DOJmp on el cub té una posició final de: (-10, 3, 5), una força de salt de 3f, 1 salt i dura 1.5f segons l'animació
            transform.DOJump(new Vector3(-10, 3, 5), 3f, 1, 1.5f).OnComplete(AnimationFinished);
        }
    }

    public void ResetAnimation()
    {
        isAnimationFinished = false;
        transform.position = originalPos;
    }

    private void AnimationFinished()
    {
        isAnimationFinished = true;
    }

}
