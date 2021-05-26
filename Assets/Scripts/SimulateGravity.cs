using UnityEngine;

public class SimulateGravity : MonoBehaviour
{
    [SerializeField] private float gravitationalConstant = 6.67f;
    [SerializeField] private SpriteRenderer arrowSprite;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float maxForce=0f;

    private Rigidbody2D rb;
    private float gM1M2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gM1M2 = gravitationalConstant * (playerRigidbody.mass * rb.mass);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Vector2 direction =  (rb.position - playerRigidbody.position);
        if (!(direction != (Vector2.zero))) return;
        float forceMagnitude = gM1M2 / direction.sqrMagnitude;
        playerRigidbody.AddForce(direction.normalized * Mathf.Min(forceMagnitude, maxForce));
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        arrowSprite.enabled = false;
        Time.timeScale = 1f;
    }
}
