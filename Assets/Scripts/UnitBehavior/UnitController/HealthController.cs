using UnityEngine;

[System.Serializable]
public class HealthController
{
    private UnitScript _unitScript;

    private double maxHealth;
    private double currentHealth;
    private bool isPoisoned = false;

    // Events to manage unit health
    public delegate void HealthChangedDelegate(double newHealth, double maxHealth);
    public event HealthChangedDelegate OnHealthChanged;
    public delegate void UnitDeathDelegate();
    public event UnitDeathDelegate OnUnitDeath;

    public HealthController(UnitScript unitScript)
    {
        _unitScript = unitScript;
        currentHealth = _unitScript.unitStats.Health;
        maxHealth   = _unitScript.unitStats.Health;
    }

    //private void Update()
    //{
    //    if (isPoisoned)
    //    {
    //        //GetComponent<Renderer>().material.color = Color.red;
    //        _meshUnit.materials[0] = MaterialPoison;
    //        TakeDamage(maxHealth * 0.15 * Time.deltaTime);
    //    }
    //    else
    //    {
    //        _meshUnit.materials[0] = _originalColor;
    //    }

    //    UpdateHealthSlider(); // Actualiza el slider en cada frame        
    //}

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
    public void Poisoned()
    {
        TakeDamage(maxHealth * 0.15 * Time.deltaTime);
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
        // Invoke OnUnitDeath event
        OnUnitDeath?.Invoke();
        // Destroy the unit
        GameObject.Destroy(_unitScript.gameObject,3.2f);

    }

    public double CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public bool IsPoisoned { get => isPoisoned; set => isPoisoned = value; }
}