using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecks : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Spike")
        {
            StartCoroutine(playerDeath());
        }
    }

    IEnumerator playerDeath()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(.5f);
        Time.timeScale = 1;
        GameManager.isDead = true;
        Destroy(gameObject);
    }
}
