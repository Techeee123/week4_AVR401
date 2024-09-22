using UnityEngine;

public class FireballShooter : MonoBehaviour
{
    public GameObject fireballPrefab; // Assign your fireball prefab here in the Inspector
    public Transform firePoint; // The point from where the fireball will be spawned
    public float fireballSpeed = 10f; // Speed of the fireball

    void Update()
    {
        // Check for input to shoot the fireball (e.g., when pressing spacebar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootFireball();
        }
    }

    void ShootFireball()
    {
        // Create a fireball instance
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody component to add velocity
        Rigidbody rb = fireball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Make the fireball move forward
            rb.velocity = firePoint.forward * fireballSpeed;
        }
    }
}
