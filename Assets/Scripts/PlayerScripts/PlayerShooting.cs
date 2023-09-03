using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform FirePoint;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bullet = Instantiate(Bullet, FirePoint.position, Quaternion.identity);

            PlayerBullet bulletScript = bullet.GetComponent<PlayerBullet>();

            bulletScript.SetDirection(PlayerMovement.FaceRight ? Vector2.right : Vector2.left);

        }
    }
}
