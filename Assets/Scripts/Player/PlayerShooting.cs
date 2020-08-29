using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bullet_speed = 100f;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Bullet Instantiate Called");
            GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as GameObject;
            if (bulletInstance.GetComponent<Bullet>() != null)
            {
                bulletInstance.GetComponent<Bullet>().setVelocity(bullet_speed);
            }
            else
            {
                Debug.Log("bulletInstance.GetComponent<Bullet>() not found");
            }
            
            
        }
    }

}
