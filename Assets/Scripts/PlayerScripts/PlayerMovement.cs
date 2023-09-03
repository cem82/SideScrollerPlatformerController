using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxSpeed;
    private Rigidbody2D rb;
    public static bool FaceRight = true;
    CollisionCheck cc;
    private bool isFlipping = false; 

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        rb = GetComponentInParent<Rigidbody2D>();
        cc = GetComponent<CollisionCheck>();

    }

    private void Update()
    {
        if (GameManager.rotateMode == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
            rb.velocity = new Vector2(Mathf.Clamp(movement.x, -maxSpeed, maxSpeed), rb.velocity.y);

            if (horizontalInput > 0 && !FaceRight && !isFlipping)
            {
                Flip(true); 
            }
            else if (horizontalInput < 0 && FaceRight && !isFlipping)
            {
                Flip(false); 
            }
        }
    }

    private void Flip(bool newFaceRight)
    {
        if (FaceRight != newFaceRight) 
        {
            isFlipping = true;

            spriteRenderer.flipX = !spriteRenderer.flipX;
            FaceRight = newFaceRight;

            isFlipping = false; 
        }
    }
}