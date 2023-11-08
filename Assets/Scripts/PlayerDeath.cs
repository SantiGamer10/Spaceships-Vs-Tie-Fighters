using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private float currentHP;
    [SerializeField] public float damageAmount = 10f;

    public event EventHandler DeathPlayer;

    public void Damage(float amount)
    {
        currentHP -= amount;

        if (currentHP <= 0f)
        {
            DeathPlayer?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}
