using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatingthescript : MonoBehaviour
{
    public float rotationSpeed = 90.0f; // Degrees per second

    private Quaternion targetRotation;
    private Quaternion initialRotation;
    private bool isRotating = false;

    private void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = initialRotation;
    }

    private void Update()
    {
        if (!isRotating && GameManager.rotateMode)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                targetRotation *= Quaternion.Euler(0, 0, -90); 
                StartCoroutine(RotateCoroutine(targetRotation));
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                targetRotation *= Quaternion.Euler(0, 0, 90);
                StartCoroutine(RotateCoroutine(targetRotation));
            }
        }
    }

    private IEnumerator RotateCoroutine(Quaternion target)
    {
        isRotating = true;
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;

        while (elapsedTime < (90 / rotationSpeed))
        {
            transform.rotation = Quaternion.Slerp(startRotation, target, elapsedTime / (90 / rotationSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = target;
        isRotating = false;
    }

}
