using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float bashForce;
    private Rigidbody2D rb;
    private Transform playerLocation;

    private void OnEnable()
    {
        DashDirection.StartPullAction += SlowPlayer;
        DashDirection.EndPullAction += LaunchPlayer;
    }

    private void OnDisable()
    {
        DashDirection.StartPullAction -= SlowPlayer;
        DashDirection.EndPullAction -= LaunchPlayer;
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
        Time.timeScale = 0.1f;
    }
    

    private void LaunchPlayer(Vector2 direction)
    {
        Time.timeScale = 1f;
        rb.velocity = Vector2.zero;
        rb.AddForce(direction*bashForce,ForceMode2D.Impulse);
    }
}
