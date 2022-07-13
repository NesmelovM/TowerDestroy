using UnityEngine;

public class EnemyCanonRotate : MonoBehaviour
{
    [SerializeField] private GameObject _muzzle;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Quaternion _currentRotation;

    private void Start()
    {
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _currentRotation = _maxRotation;
    }
    private void Update()
    {
        Rotation(_currentRotation);
        RotationTimer();
    }

    private void Rotation(Quaternion quaternion)
    {
        _muzzle.transform.rotation = Quaternion.Lerp(_muzzle.transform.rotation, quaternion, _speedRotation * Time.deltaTime);
    }

    private void RotationTimer()
    {
        if (_muzzle.transform.rotation == _maxRotation)
        {
            _currentRotation = _minRotation;
        }
        if (_muzzle.transform.rotation == _minRotation)
        {
            _currentRotation = _maxRotation;
        }
    }
}
