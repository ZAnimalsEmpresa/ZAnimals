using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public double maxHealth = 100.0;
    public double currentHealth;

    // Events to manage unit health
    public delegate void HealthChangedDelegate(double newHealth, double maxHealth);
    public event HealthChangedDelegate OnHealthChanged;
    public delegate void UnitDeathDelegate();
    public event UnitDeathDelegate OnUnitDeath;

    private Animator _animator;

    private void Start()
    {
        currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
    }

    // Method to reduce unit health
    public void TakeDamage(double damageAmount)
    {
        currentHealth -= damageAmount;

        // Ensuring that health is not less than zero
        currentHealth = Mathf.Max((float)currentHealth, 0f);

        // Invoke the OnHealthChanged event
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        // If health reaches zero, the unit dies
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method to restore unit health
    public void Heal(double healAmount)
    {
        currentHealth += healAmount;

        // Ensure that health does not exceed maximum health
        currentHealth = Mathf.Min((float)currentHealth, (float)maxHealth);

        // Invoke the OnHealthChanged event
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    // Method for handling unit death
    private void Die()
    {
        _animator.SetBool("isDead", true);
        // Invoke OnUnitDeath event
        OnUnitDeath?.Invoke();

        // Destroy the unit
        Destroy(this.gameObject, 4);
    }
}
