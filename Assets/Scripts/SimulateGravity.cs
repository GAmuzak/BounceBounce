using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateGravity : MonoBehaviour
{

    [SerializeField] private float G = 6.67f;
    [SerializeField] private bool applyGravity = false;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        applyGravity = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rbAttract = other.GetComponent<Rigidbody2D>();

        Vector2 direction = rbAttract.position - rb.position;
        float distance = direction.magnitude;

        float forceMagnitude = G * (rbAttract.mass * rb.mass) / Mathf.Pow(distance, 2);
        
        rbAttract.AddForce(-direction * forceMagnitude );

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        applyGravity = false;
    }
}
