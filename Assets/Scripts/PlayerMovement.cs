using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float bashForce;
    [SerializeField] private float maxSpeed;
    
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
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(rb.velocity.sqrMagnitude > maxSpeed*maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        
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
