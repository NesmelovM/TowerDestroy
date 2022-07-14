using UnityEngine;

public class CanonShoot : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletParent;


    [SerializeField] private float _timeReload;

    private float _tempTimeReload;
    private bool _canShoot = true;
    private bool _isPlayer;

    private void Start()
    {
        _tempTimeReload = _timeReload;

        if(gameObject.transform.parent.CompareTag("Player"))
        {
            _isPlayer = true;
        }
    }
    void Update()
    {
        ShootInTouch();
        ReloadTimer();
    }

    private void ShootInTouch()
    {
        if (_isPlayer)
        {
            if (Input.touchCount > 0)
            {
                if (_canShoot)
                {
                    Shoot();
                }
            }
        }
        else
        {
            if (_canShoot)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation, _bulletParent);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.right * Random.Range(8,15), ForceMode2D.Impulse);
        _canShoot = false;
    }

    private void ReloadTimer()
    {
        if (_canShoot == false)
        {
            _tempTimeReload -= Time.deltaTime;
            if (_tempTimeReload <= 0)
            {
                _canShoot = true;
                _tempTimeReload = _timeReload;
            }
        }
    }
}
