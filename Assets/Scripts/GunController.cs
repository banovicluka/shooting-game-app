using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform bulletSpawnPoint; // Postion where the bullet will be spawned
    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f; // Speed factor of the bullet

     private KillTracker killTracker;


    void Start(){
        bulletSpeed = 100.0f;
        killTracker = GameObject.FindObjectOfType<KillTracker>();
    }

    void Update()
    {
        Shoot();
    }
    public void Shoot()
    {
        if (killTracker != null && killTracker.gameEnded)
        {
            return; // do not allow shooting if the game is over
        }

        // if the player press the space bar or left click, then shoot
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(bulletPrefab); // Create a new bullet
            bullet.transform.position = bulletSpawnPoint.position; // Set the bullet position to the bulletSpawnPoint position
            // Shoot the bullet by adding velocity to the rigigbody component of the bullet
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed; 
        }
    }

}
