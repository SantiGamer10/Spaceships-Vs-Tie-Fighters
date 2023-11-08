using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserShooter : MonoBehaviour
{
    [SerializeField] private Vector2 speed;

    // Update is called once per frame
    void Update()
    {
        MoveLaser();
    }
    private void MoveLaser()
    {
        float newX = transform.position.x + (speed.x * Time.deltaTime);
        float newY = transform.position.y + (speed.y * Time.deltaTime);
        transform.position = new Vector2(newX, newY);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AsteroidMovement>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
