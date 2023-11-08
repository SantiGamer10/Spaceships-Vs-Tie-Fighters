using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static HealthPoints;

public class HealthPoints : MonoBehaviour, IDamageable
{
    [SerializeField] public float maxHP = 100f;
    [SerializeField] public float currentHP;
    [SerializeField] public Image hPBar;
    [SerializeField] public Action onChange;

    public float CurrentHP 
    {
        get 
        {
            return currentHP;
        }
        set 
        {
            currentHP = value;
            onChange?.Invoke();
        }
    }
    public float Ratio => currentHP / maxHP;
    private void Awake() 
    {
        currentHP = maxHP;
    } 
    public void Damage(float amount) 
    {
        currentHP = Mathf.Max(0, currentHP - amount); ;

        if (currentHP == 0f) 
        {
            Destroy(gameObject);
        }
    }

    public void Heal(float amount) 
    {
        currentHP += amount;

        if (currentHP > maxHP) 
        {
            currentHP = maxHP;
        }
    }

    public interface IDamageable
    {
        void Damage(float amount);
    }
}
