using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    [Header("Dependencies")]
    public Slider healthSlider;
    public Image colorFill;

    // Private
    private UnitScript _unit;
    private HealthController _healthController;
    private void Start()
    {
        _healthController = GetComponent<UnitScript>().healthController;
    }

    private void Update()
    {
        UpdateHealthSlider();

        if (_healthController.IsPoisoned) { 
            PoisonedColorBar();
        } else {
            ResetColorBar();

        }
    }

    private void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            // Actualiza el valor del slider según la vida actual
            healthSlider.value = (float)(_healthController.CurrentHealth);
        }
    }
    public void PoisonedColorBar()
    {
        colorFill.color = Color.magenta;
    }
    public void ResetColorBar()
    {
        colorFill.color = Color.green;
    }
}
