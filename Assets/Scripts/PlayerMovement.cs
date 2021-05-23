using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private DashDirection dashDirection;
    [SerializeField] private float bashForce;
    private Rigidbody2D rb;
    private Transform playerLocation;

    private void OnEnable()
    {
        dashDirection.StartPullAction += SlowPlayer;
        dashDirection.EndPullAction += LaunchPlayer;
    }

    private void OnDisable()
    {
        dashDirection.StartPullAction -= SlowPlayer;
        dashDirection.EndPullAction -= LaunchPlayer;
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerLocation = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(1)) return;
        playerLocation.position = Vector2.zero;
        rb.velocity = Vector2.zero;
    }

    private void SlowPlayer()
    {
        rb.velocity *= 0.1f;
    }

    private void LaunchPlayer(Vector2 direction)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(direction*bashForce,ForceMode2D.Impulse);
    }
}
