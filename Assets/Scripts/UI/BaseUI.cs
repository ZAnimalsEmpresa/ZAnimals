using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUI : MonoBehaviour
{
    [Header("Dependencies")]
    public Slider hpSlider;

    // Private
    private BaseScript _base;
    private BaseHPController _baseHPController;
    private void Start()
    {
        _baseHPController = GetComponent<BaseScript>().baseHPController;
    }

    private void Update()
    {
        UpdateHPSlider();
    }

    private void UpdateHPSlider()
    {
        if (hpSlider != null)
        {
            // Actualiza el valor del slider según el hp actual
            hpSlider.value = (float)(_baseHPController.CurrentHP);
        }
    }
}
