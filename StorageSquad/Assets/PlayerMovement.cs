using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the player moves

    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector2 movement; // The vector to store the direction of the player's movement

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component from the player so we can move it
    }

    // Update is called once per frame
    void Update()
    {
        // Input gathering
        movement.x = Input.GetAxisRaw("Horizontal"); // Get input from the horizontal axis (A, D, Left Arrow, Right Arrow)
        movement.y = Input.GetAxisRaw("Vertical"); // Get input from the vertical axis (W, S, Up Arrow, Down Arrow)
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. It's preferred for updating physics (movement, collisions).
    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); // Move the player
    }
}

