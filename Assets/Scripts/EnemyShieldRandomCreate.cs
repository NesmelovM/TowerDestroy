using UnityEngine;

public class EnemyShieldRandomCreate : MonoBehaviour
{
    [SerializeField] private GameObject _shieldPrefab;
    [SerializeField] private Transform _shieldPosition;
    [SerializeField] private Transform _shieldParent;

    private float _tempTimeReload;

    private void Start()
    {
        _tempTimeReload = Random.Range(10f, 15f);
    }
    void Update()
    {
        CreateEnemyShield();
    }

    private void CreateEnemyShield()
    {
        _tempTimeReload -= Time.deltaTime;
        if (_tempTimeReload <= 0)
        {
            GameObject shield = Instantiate(_shieldPrefab, _shieldPosition.position, _shieldPosition.rotation, _shieldParent);
            _tempTimeReload = Random.Range(10f, 15f);
        }
    }

}
