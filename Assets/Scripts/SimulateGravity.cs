using UnityEngine;

public class SimulateGravity : MonoBehaviour
{

    [SerializeField] private readonly float GravitationalConstant = 6.67f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
            return;
        Rigidbody2D rbAttract = other.GetComponent<Rigidbody2D>();
        Vector2 direction =  (rb.position - rbAttract.position).normalized;
        float distance = direction.magnitude;
        float forceMagnitude = GravitationalConstant * (rbAttract.mass * rb.mass) / Mathf.Pow(distance, 2);
        rbAttract.AddForce(direction * forceMagnitude );

    }


}
