using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the player moves
    public Collision obstacle;

    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector2 movement; // The vector to store the direction of the player's movement
    private SpriteRenderer m_SpriteRenderer;
    private bool faceLeft;
    private bool immune;
    private Vector2 defaultPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component from the player so we can move it
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        faceLeft = true;
        immune = false;
        defaultPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Input gathering
        movement.x = Input.GetAxisRaw("Horizontal"); // Get input from the horizontal axis (A, D, Left Arrow, Right Arrow)
        movement.y = Input.GetAxisRaw("Vertical"); // Get input from the vertical axis (W, S, Up Arrow, Down Arrow

        if (movement.x == -1 && faceLeft == false) {
            m_SpriteRenderer.flipX = !m_SpriteRenderer.flipX;
            faceLeft = true;
        } else if (movement.x == 1 && faceLeft == true) {
            m_SpriteRenderer.flipX = !m_SpriteRenderer.flipX;
            faceLeft = false;
        }
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. It's preferred for updating physics (movement, collisions).
    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); // Move the player
    }

    void OnCollisionEnter2D(Collision2D col) {
        print("Oww\n");
        print(col.gameObject.tag);
        if (col.gameObject.tag == "Obstacle" && immune == false) {
            rb.MovePosition(defaultPosition);
            // Be sure to remove the box that the player picked up
        }
    }
}

