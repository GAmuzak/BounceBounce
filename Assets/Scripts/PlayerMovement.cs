using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] RotateArrow r;
    [SerializeField] float bashForce;
    Rigidbody2D rb;
    Transform playerLoc;
    void OnEnable()
    {
        r.StartPullAction += Test1;
        r.EndPullAction += Test2;
    }

    void OnDisable()
    {
        r.StartPullAction -= Test1;
        r.EndPullAction -= Test2;
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerLoc = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(1)) return;
        playerLoc.position = Vector2.zero;
        rb.velocity = Vector2.zero;
    }

    void Test1()
    {
        rb.velocity /= 10;
    }

    void Test2(Vector2 dirn)
    {
        Vector2 randomVector = new Vector2(Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f));
        randomVector.Normalize();
        rb.velocity = Vector2.zero;
        rb.AddForce(dirn*bashForce,ForceMode2D.Impulse);
    }
}
