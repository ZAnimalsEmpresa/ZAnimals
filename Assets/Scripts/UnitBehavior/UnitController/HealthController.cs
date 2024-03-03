using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public double maxHealth = 100.0;
    public double currentHealth;
    public bool isPoisoned = false;
    private Material _originalColor;
    public Slider healthSlider; // Referencia al slider de vida en el inspector

    // Events to manage unit health
    public delegate void HealthChangedDelegate(double newHealth, double maxHealth);
    public event HealthChangedDelegate OnHealthChanged;
    public delegate void UnitDeathDelegate();
    public event UnitDeathDelegate OnUnitDeath;

    private Animator _animator;

    public Material MaterialPoison;
    private MeshRenderer _meshUnit;

    private void Start()
    {
        currentHealth = maxHealth;
        _meshUnit = GetComponent<MeshRenderer>();
        _originalColor = _meshUnit.materials[0];
        UpdateHealthSlider(); // Actualiza el slider al inicio
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isPoisoned)
        {
            //GetComponent<Renderer>().material.color = Color.red;
            _meshUnit.materials[0] = MaterialPoison;
            TakeDamage(maxHealth * 0.15 * Time.deltaTime);
        }
        else
        {
            _meshUnit.materials[0] = _originalColor;
        }

        UpdateHealthSlider(); // Actualiza el slider en cada frame        
    }

    public void TakeDamage(double damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Max((float)currentHealth, 0f);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

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

    private void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            // Actualiza el valor del slider según la vida actual
            healthSlider.value = (float)(currentHealth);
        }
    }
}