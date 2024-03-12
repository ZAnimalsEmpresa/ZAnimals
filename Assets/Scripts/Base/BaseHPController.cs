using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BaseHPController
{
    private BaseScript _baseScript;

    private double _maxHP;
    private double _currentHP;

    // Events to manage base hp
    public delegate void HPChangedDelegate(double newHP, double maxHP);
    public event HPChangedDelegate OnHPChanged;
    public delegate void BaseDestroyDelegate();
    public event BaseDestroyDelegate OnBaseDestroy;

    public UnityEvent OnDeadBase;

    public BaseHPController(BaseScript baseScript, UnityEvent onDeadBase)
    {
        _baseScript = baseScript;
        _currentHP = _baseScript.baseStats.BaseHP;
        _maxHP = _baseScript.baseStats.BaseHP;
        OnDeadBase = onDeadBase;
    }

    public void TakeDamage(double damageAmount)
    {
        _currentHP -= damageAmount;
        _currentHP = Mathf.Max((float)_currentHP, 0f);
        OnHPChanged?.Invoke(_currentHP, _maxHP);

        if (_currentHP <= 0)
        {
            Die();
        }
    }

    // Method for handling base death
    private void Die()
    {
        // Invoke OnBaseDeath event
        OnBaseDestroy?.Invoke();

        if (OnDeadBase != null)
            OnDeadBase.Invoke();
        // Destroy the base
        //GameObject.Destroy(_baseScript.gameObject);
    }

    public double CurrentHP { get => _currentHP; set => _currentHP = value; }
}
