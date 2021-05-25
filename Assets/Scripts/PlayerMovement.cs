using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float bashForce;
    [SerializeField] private float maxSpeed;
    
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
        // Debug.Log(rb.velocity.magnitude);
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        
        // this next bit can cause the game to glitch out, so make sure to replace it eventually with a screen reload via R or maybe right click
        if (!Input.GetMouseButtonDown(1)) return;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        
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
