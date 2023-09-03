using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGravity : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float gravity;

    float maxVerticalVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxVerticalVelocity = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.rotateMode == true)
        {
            rb.gravityScale = 0;
        } else
        {
            rb.gravityScale = gravity;
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.y = Mathf.Clamp(velocity.y, -maxVerticalVelocity, maxVerticalVelocity);
        rb.velocity = velocity;
    }
}
