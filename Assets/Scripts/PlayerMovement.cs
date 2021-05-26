using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float bashForce;
    
    private Rigidbody2D rb;

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
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(1)) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
