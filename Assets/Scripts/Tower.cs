using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float fireDelay, radius, damage;
    public Transform bulletPrefab;
    public LayerMask enemyLayer;

    private float _timeToFire;
    private Transform _gun, _enemy, _firePoint;

    void Start()
    {
        _timeToFire = fireDelay;
        _gun = transform.GetChild(0);
        _firePoint = _gun.GetChild(0);
    }

    void Update()
    {
        if (_timeToFire > 0)
            _timeToFire -= Time.deltaTime;
        else if (_enemy)
            Fire();

        if (_enemy)
        {
            Vector3 lookAt = _enemy.position;
            lookAt.y = _gun.position.y;
            _gun.rotation = Quaternion.LookRotation(_gun.position - lookAt);

            if(Vector3.Distance(_gun.position, _enemy.position) > radius)
                _enemy = null;
            
        }
        else
            FindEnemy();
        
    }

    void Fire()
    {
        Transform bullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity);
        bullet.LookAt(_enemy.GetChild(0).GetChild(0));
        bullet.GetComponent<Bullet>().damage = damage;

        _timeToFire = fireDelay;
    }

    void FindEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, enemyLayer);

        if (colliders.Length > 0)
        {
            _enemy = colliders[0].transform;
        }
    }
}
