using UnityEngine;

public class SimulateGravity : MonoBehaviour
{

    [SerializeField] private float gravitationalConstant = 6.67f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
        Vector2 direction =  (rb.position - playerRigidbody.position);
        if (direction.Equals(Vector2.zero)) return;
        float distance = direction.magnitude;
        float forceMagnitude = gravitationalConstant * (playerRigidbody.mass * rb.mass) / Mathf.Pow(distance, 2);
        playerRigidbody.AddForce(direction.normalized * forceMagnitude);

    }


}
