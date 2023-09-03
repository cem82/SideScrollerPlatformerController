using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float gravityScale;
    [SerializeField] float fallGravityScale;
    CollisionCheck cc;

    [SerializeField] float jumpStartTime;

    float rememberButton;
    [SerializeField] float rememberButtonTime;

    float coyote;
    [SerializeField] float coyoteTime;
    Rigidbody2D rb;
    [SerializeField] float cutJump;

    [SerializeField] float airJump;

    public float maxVerticalVelocity = 10f;


    public bool madeIt;

    public float gravityStore;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        cc = GetComponent<CollisionCheck>();
    }

    private void Update()
    {
        if(GameManager.rotateMode == false)
        {

            if(madeIt)
            {
                rb.gravityScale = gravityScale;
                madeIt = false;

                if(gravityStore == 0)
                {
                    rb.gravityScale = fallGravityScale;
                }
            }
            coyote -= Time.deltaTime;

            if (cc.OnGround)
            {
                coyote = coyoteTime;
            }

            rememberButton -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.C))
            {
                rememberButton = rememberButtonTime;
            }

            if (Input.GetKeyUp(KeyCode.C))
            {
                if (rb.velocity.y > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * cutJump);
                }
            }
            if (rememberButton > 0 && coyote > 0 || (airJump > 0 && Input.GetKeyDown(KeyCode.C)))
            {
                rememberButton = 0;
                coyote = 0;
                if (airJump > 0)
                {
                    airJump--;
                }

                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            if (rb.velocity.y > 0f)
            {
                rb.gravityScale = gravityScale;
              
            }
            else
            {
                rb.gravityScale = fallGravityScale;

            }
        }  else
        {
            gravityStore = rb.gravityScale;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0f;
            madeIt = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.y = Mathf.Clamp(velocity.y, -maxVerticalVelocity, maxVerticalVelocity);
        rb.velocity = velocity;
    }
}
