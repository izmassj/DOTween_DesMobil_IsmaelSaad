using DG.Tweening;
using UnityEngine;

public class ObjectBController : MonoBehaviour
{
    [SerializeField] GameObject cubeB1;
    [SerializeField] GameObject cubeB2;

    private Vector3 originalPosB1 = Vector3.zero;
    private Vector3 originalPosB2 = Vector3.zero;
    private bool isAnimationFinished = false;

    private void Awake()
    {
        originalPosB1 = cubeB1.transform.position;
        originalPosB2 = cubeB2.transform.position;
    }

    public void RunAnimation()
    {
        Sequence seq = DOTween.Sequence();

        // CubeB2 es mou endavant
        seq.Append(cubeB1.transform.DOMoveZ(3, 1));

        // CubeB2 es mou endavant al mateix temps
        seq.Join(cubeB2.transform.DOMoveZ(3, 1));

        // CubeB1 gira
        seq.Append(cubeB1.transform.DORotate(new Vector3(0, 180, 0), 1));

        // CubeB2 puja
        seq.Append(cubeB2.transform.DOMoveY(3, 1));

        // Tots dos tornen al lloc original sincronitzats
        seq.Append(
            cubeB1.transform.DOMove(new Vector3(10, 1, 0), 1)
        );
        seq.Join(
            cubeB2.transform.DOMove(new Vector3(12, 1, 0), 1)
        );

        seq.OnComplete(AnimationFinished);
    }

    public void ResetAnimation()
    {
        isAnimationFinished = false;
        cubeB1.transform.position = originalPosB1;
        cubeB2.transform.position = originalPosB2;
    }

    private void AnimationFinished()
    {
        isAnimationFinished = true;
    }
}
