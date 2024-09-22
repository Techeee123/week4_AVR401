using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // The bullet prefab to shoot
    [SerializeField] private Transform bulletSpawnPoint; // Where the bullet will spawn
    [SerializeField] private float fireRate = 0.5f; // Delay between shots
    private float nextFireTime = 0f; // Tracks the time for the next shot

    void Update()
    {
        // Check if the player presses the shoot button and if it's time to shoot
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Set the time for the next shot
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the spawn point with the player's rotation
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Optional: Apply rotation adjustment to the bullet (if needed)
        bullet.transform.rotation = bulletSpawnPoint.rotation;

        // Alternative: Applying local rotation via quaternion
        Quaternion localRotation = Quaternion.Euler(0, 0, bulletSpawnPoint.eulerAngles.z);
        bullet.transform.rotation = localRotation;
    }
}
