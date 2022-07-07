using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Transform _firepoint;
    [SerializeField] private float _radius;
    [SerializeField] private float _duration;
    [SerializeField] private int _shotsAmount;

    private Target _target;
    private float _timer;
    private int _counter;

    private void Start()
    {
        _counter = _shotsAmount;
        //_timer = _duration;
    }

    private void FixedUpdate()
    {
        SearchTarget();

        if(_target != null)
            transform.LookAt(_target.transform);

        if(_target != null && _timer <= 0.01f)
        {
            Shoot();
        }

        _timer -= Time.deltaTime;
    }

    public void SearchTarget()
    {
        var colliders = Physics.OverlapSphere(transform.position, _radius);

        if(colliders.Length > 0 && _target == null)
        {
            var target = colliders[Random.Range(0, colliders.Length)].gameObject.GetComponent<Target>();
            
            if(target != null)
            {
                _target = target;
            }
        }
    }

    public void Shoot()
    {
        var clone = Instantiate(_projectile, _firepoint.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().velocity = transform.forward * 10;

        _timer = _duration;
        _counter--;

        if(_counter <= 0)
        {
            Destroy(gameObject);
        }
    }
}
