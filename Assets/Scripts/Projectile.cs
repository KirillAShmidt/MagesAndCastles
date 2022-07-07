using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _maxDistance;

    private Vector3 _startPosition;

    public void Start()
    {
        _startPosition = transform.position;
    }

    public void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _startPosition) > _maxDistance)
        {
            Debug.Log("Died");
            Die();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        var target = collision.collider.GetComponent<Target>();

        if (target != null)
        {
            target.GetComponent<IHaveHealth>().TakeDamage(_damage);
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
