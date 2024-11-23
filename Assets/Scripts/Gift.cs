using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gift : MonoBehaviour
{
    [SerializeField] private Transform target; // Assign the target object in the Inspector
    [SerializeField] private float bounceScale = 1.2f; // Scale factor for the bounce
    [SerializeField] private float duration = 0.5f; // Duration of one bounce

    private Tween bounceTween; 

    private void Start()
    {
        if (target == null)
            target = transform;

        StartRandomAnim();
    }

    private void StartRandomAnim()
    {
        float delay = Random.Range(0, 0.5f);

        // Create and store the tween
        bounceTween = target.DOScale(bounceScale, duration)
            .SetEase(Ease.InOutBounce)
            .SetDelay(delay)
            .SetLoops(-1, LoopType.Yoyo)
            .SetAutoKill(false); // Prevents the tween from being automatically killed
    }

    private void OnDestroy()
    {
        // Kill the tween to prevent DOTween from trying to animate a destroyed object
        if (bounceTween != null && bounceTween.IsActive())
        {
            bounceTween.Kill();
        }
    }


    /*    private void Start()
        {
            if (target == null)
                target = transform;

            StartCoroutine(RandomAnim());

        }

        private IEnumerator RandomAnim()
        {
            yield return new WaitForSeconds(Random.Range(0,0.5f));
            target.DOScale(bounceScale, duration)
                .SetEase(Ease.InOutBounce)
                .SetLoops(-1, LoopType.Yoyo);
        }

        private void OnDestroy()
        {
            StopCoroutine(RandomAnim());
        }*/
}
