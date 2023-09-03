using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    public float rotationAmount = 10.0f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            float rotationAngle = rotationAmount * -horizontalInput;

            transform.rotation = Quaternion.Euler(0f, 0f, -rotationAngle);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }

}

