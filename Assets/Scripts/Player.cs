using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
   
    public float playerSpeed = 5f;

    
    public float smoothTime = 0.2f; 

   
    public float tremorGracePeriod = 0.15f; 

    private Rigidbody2D rb;
    private Vector2 currentVelocity; 
    
    // Input State
    private float lastInputTime;
    private float lastDirectionY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Gather Raw Input
        float rawDirectionY = 0f;
        
        // Safety check for Input System
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) rawDirectionY = 1f;
            else if (Keyboard.current.sKey.isPressed) rawDirectionY = -1f;
        }
             // 2. Apply Tremor Filtering (Debouncing)
        // If we have input, update the time and store the direction
        if (rawDirectionY != 0f)
        {
            lastInputTime = Time.time;
            lastDirectionY = rawDirectionY;
        }
        else
        {
            // If no input, check if we are still within the "Grace Period"
            // If the user's finger shook off the key for 0.1s, we pretend they are still holding it.
            if (Time.time - lastInputTime > tremorGracePeriod)
            {
                lastDirectionY = 0f; // Only stop after the grace period expires
            }
        }
    }

    void FixedUpdate()
    {
        // 3. Movement Execution
        Vector2 targetVelocity = new Vector2(0, lastDirectionY * playerSpeed);

        // We use SmoothDamp with 'smoothTime' to create a fluid motion that is easier
        // for the eyes to track, reducing motion sickness and cognitive load.
        rb.linearVelocity = Vector2.SmoothDamp(
            rb.linearVelocity, 
            targetVelocity, 
            ref currentVelocity, 
            smoothTime
        );
    }
}