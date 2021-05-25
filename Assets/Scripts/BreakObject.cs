using UnityEngine;

public class BreakObject : MonoBehaviour
{
    [SerializeField] private float blastForce;
    [SerializeField] private Transform playerTransform;
    public void OnObjectBreak()
    {
        foreach (Transform child in transform)
        {
            Vector2 shootDirection = child.transform.position-playerTransform.position;
            child.GetComponent<Rigidbody2D>().AddForce(shootDirection.normalized*blastForce, ForceMode2D.Impulse);
        }
    }
}
