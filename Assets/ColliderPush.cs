using UnityEngine;

public class ColliderPush : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _destroyTimer;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(_damage);
        }
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(_damage);
        }       
    }

    private void Update()
    {
        TimeToDestroy();
    }

    private void TimeToDestroy()
    {
        _destroyTimer -= Time.deltaTime;

        if (_destroyTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
