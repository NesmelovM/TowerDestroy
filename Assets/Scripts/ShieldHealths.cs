using System;
using UnityEngine;

public class ShieldHealths : MonoBehaviour
{
    [SerializeField] private int _maxHits;

    [SerializeField] private int _current;

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

    public int Max => _maxHits;

    private void Start()
    {
        Current = _maxHits;
    }

    public void TakeDamage()
    {
        Current--;
    }
    private void Update()
    {
        if (Current == 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}