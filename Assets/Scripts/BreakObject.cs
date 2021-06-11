using System.Collections;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    [SerializeField] private float blastForce;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private AnimationCurve ac;


    public void OnObjectBreak()
    {
        foreach (Transform child in transform)
        {
            Vector2 shootDirection = child.transform.position-playerTransform.position;
            child.GetComponent<Rigidbody2D>().AddForce(shootDirection.normalized*blastForce, ForceMode2D.Impulse);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(FadeAway());
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator FadeAway()
    {
        yield return new WaitForSeconds(1f);
        LeanTween.alpha(gameObject, 0f, 0.5f).setEase(ac);
    }
}
