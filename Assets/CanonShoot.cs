using UnityEngine;

public class CanonShoot : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] int _bulletForce;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation, _firePoint);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.right * _bulletForce, ForceMode2D.Impulse);
    }
}
