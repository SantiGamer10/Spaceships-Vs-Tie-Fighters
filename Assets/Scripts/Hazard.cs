using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HealthPoints;

public class Hazard : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    protected void TakeDamage(IDamageable damageable) 
    {
        damageable.Damage(damageAmount);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            other.gameObject.GetComponent<PlayerDeath>().Damage(damageAmount);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("collision detected!");
            Destroy(gameObject);
        }
    }
}
