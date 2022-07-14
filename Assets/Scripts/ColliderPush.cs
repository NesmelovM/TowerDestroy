using UnityEngine;

public class ColliderPush : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _destroyTimer;

    private const string _player = "Player";
    private const string _enemy = "Enemy";
    private const string _canon = "Canon";
    private const string _shield = "Shield";

    private void Update()
    {
        TimeToDestroy();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        CheckObjectAndHit(other);
    }

    private void CheckObjectAndHit(Collision2D other)
    {
        tag = other.transform.parent.tag;
        switch (tag)
        {
            case _enemy:
                Debug.Log("hit enemy");
                other.transform.parent.GetComponent<Health>().TakeDamage(_damage);
                this.gameObject.GetComponent<Collider2D>().enabled = false;
                break;
            case _player:
                Debug.Log("hit player");
                other.transform.parent.GetComponent<Health>().TakeDamage(_damage);
                this.gameObject.GetComponent<Collider2D>().enabled = false;
                break;

            case _canon:
                if (this.transform.parent.tag != other.transform.parent.parent.tag)
                {
                    Debug.Log("hit canon");
                    other.gameObject.transform.parent.parent.GetComponent<Health>().TakeDamage(_damage);
                }
                break;
            case _shield:
                if (this.transform.parent.tag != other.transform.parent.parent.tag)
                {
                    other.transform.GetComponent<ShieldHealths>().TakeDamage();
                }
                break;
        }
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
