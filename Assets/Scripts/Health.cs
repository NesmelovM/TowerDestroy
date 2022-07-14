using System;
using UnityEngine;
using UnityEngine.Assertions;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _current;

    public event Action ValueChanged;

    public int Current
    {
        get => _current;
        private set
        {
            if (_current != value)
            {
                if (value < 0)
                {
                    _current = 0;
                }

                _current = value;

                ValueChanged?.Invoke();
            }
        }
    }

    public int Max => _maxHealth;

    private void Start()
    {
        Current = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Assert.IsTrue(damage >= 0);

        print($"damage - {damage}");

        Current -= damage;
    }
}