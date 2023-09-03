using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public bool OnGround { get; private set; }
    public bool OnWall { get; private set; }
    public float friction { get; private set; }

    PhysicsMaterial2D material;

    public Rigidbody2D rb;



    public Vector2 normal { get; private set; }


    void OnCollisionEnter2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetriveFriction(collision);

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetriveFriction(collision);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        OnWall = false;
        OnGround = false;
        friction = 0;
    }

    public void EvaluateCollision(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            normal = collision.GetContact(i).normal;
            OnGround |= normal.y >= 0.9f;

        }
    }

    public void RetriveFriction(Collision2D collision)
    {
        material = collision.rigidbody.sharedMaterial;

        friction = 0;

        if (material != null)
        {
            friction = material.friction;
        }
    }
}
