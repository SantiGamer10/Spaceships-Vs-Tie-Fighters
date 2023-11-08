using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    // This is a script for the asteroids' movement. These are enemies that don't shoot, but
    // they destroy the player's ship once they collide with it.
    [SerializeField] private AsteroidMovement OnDestroyedTemplate;
    public float RotationSpeed;
    public Vector2 Speed = new(0, 5);
    /* The reason why I made these last 2 variables public is because if I use "[SerializeField] private", it will give me errors on the "AsteroidSpawner"
     due to their protection.*/

    // Update is called once per frame
    void Update()
    {
        RotateAsteroid();
        MoveAsteroid();
    }

    private void RotateAsteroid()
    {
        float newZ = transform.rotation.eulerAngles.z + (RotationSpeed * Time.deltaTime);
        Vector3 newR = new(0, 0, newZ);
        transform.rotation = Quaternion.Euler(newR);
    }

    public void MoveAsteroid()
    {
        float newX = transform.position.x + (Speed.x * Time.deltaTime);
        float newY = transform.position.y + (Speed.y * Time.deltaTime);
        transform.position = new Vector2(newX, newY);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<LaserShooter>(out var asLaser))
        {
            OnLaserHit(asLaser);
        }
    }

    public void OnLaserHit(LaserShooter laser)
    {
        Debug.Log("Laser hit asteroid");

        // Make sure the laser and asteroid are being detected
        Destroy(laser.gameObject);

        if (OnDestroyedTemplate != null)
        {
            Debug.Log("Instantiating new asteroid");
            AsteroidMovement newObj = Instantiate(OnDestroyedTemplate);
            newObj.transform.position = this.transform.position;
            newObj.RotationSpeed = RotationSpeed;
            newObj.Speed = Speed;
        }
        Debug.Log("Destroying current asteroid");
        Destroy(this.gameObject);
    }
}
