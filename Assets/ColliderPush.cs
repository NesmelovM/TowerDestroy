using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPush : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == null)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(_damage);
            DestroyObject(this);
        }
    }
}
