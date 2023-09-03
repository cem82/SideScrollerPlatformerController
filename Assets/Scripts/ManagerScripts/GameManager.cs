using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isDead;
    public static bool rotateMode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotateMode == false && Input.GetKeyDown(KeyCode.Space))
        {
            rotateMode = true;
        }

        else if (rotateMode == true && Input.GetKeyDown(KeyCode.Space))
        {
            rotateMode = false;
        }

        if(isDead)
        {
            SceneManager.LoadScene(0);
            isDead = false;
        }
        
    }
}
