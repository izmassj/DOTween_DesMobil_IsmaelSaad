using DG.Tweening;
using UnityEngine;

public class ObjectBController : MonoBehaviour
{
    [SerializeField] GameObject cubeB1;
    [SerializeField] GameObject cubeB2;

    private Vector3 originalPosB1 = Vector3.zero;
    private Vector3 originalPosB2 = Vector3.zero;

    private bool isAnimationFinished = false;
    private bool isAnimationPlaying = false;

    private void Awake()
    {
        originalPosB1 = cubeB1.transform.position;
        originalPosB2 = cubeB2.transform.position;
    }

    public void RunAnimation()
    {
        if (isAnimationPlaying)
            return;

        isAnimationPlaying = true;
        isAnimationFinished = false;

        Sequence seq = DOTween.Sequence();

        seq.Append(cubeB1.transform.DOMoveZ(3, 1));
        seq.Join(cubeB2.transform.DOMoveZ(3, 1));

        seq.Append(cubeB1.transform.DORotate(new Vector3(0, 180, 0), 1));
        seq.Append(cubeB2.transform.DOMoveY(3, 1));

        seq.Append(cubeB1.transform.DOMove(new Vector3(10, 1, 0), 1));
        seq.Join(cubeB2.transform.DOMove(new Vector3(12, 1, 0), 1));

        seq.OnComplete(AnimationFinished);
    }

    public void ResetAnimation()
    {
        if (isAnimationPlaying)
            return;

        isAnimationFinished = false;

        cubeB1.transform.position = originalPosB1;
        cubeB2.transform.position = originalPosB2;
    }

    private void AnimationFinished()
    {
        isAnimationPlaying = false;
        isAnimationFinished = true;
    }
}
